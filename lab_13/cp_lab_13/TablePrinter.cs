using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace cp_lab_13
{
    // Simple, reusable table printer with preview and print support.
    // Usage:
    //   var p = new TablePrinter(this);
    //   p.PrintPreview(myDataTable, "Warehouse report");
    //   or
    //   p.Print(myDataTable, "Warehouse report");
    public class TablePrinter : IDisposable
    {
        private readonly Form _owner;
        private PrintDocument _doc;
        private DataTable _table;
        private string _title;
        private int _currentRow;
        private List<int> _colWidths;
        private Font _fontHeader = new Font("Segoe UI", 10, FontStyle.Bold);
        private Font _fontBody = new Font("Segoe UI", 9);
        private int _rowHeight;
        private int _headerHeight;
        private bool _disposed;

        public TablePrinter(Form owner)
        {
            _owner = owner ?? throw new ArgumentNullException(nameof(owner));
            _doc = new PrintDocument();
            _doc.PrintPage += OnPrintPage;
        }

        public void PrintPreview(DataTable table, string title = null)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));
            Prepare(table, title);
            using (var dlg = new PrintPreviewDialog())
            {
                dlg.Document = _doc;
                // dialog sizing can be awkward; ensure it's usable
                dlg.Width = Math.Max(600, _owner.Width);
                dlg.Height = Math.Max(600, _owner.Height);
                dlg.ShowDialog(_owner);
            }
        }

        public void Print(DataTable table, string title = null)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));
            Prepare(table, title);
            using (var pd = new PrintDialog())
            {
                pd.Document = _doc;
                if (pd.ShowDialog(_owner) == DialogResult.OK)
                {
                    _doc.Print();
                }
            }
        }

        // Convenience overloads for TWarehouse
        public void PrintPreview(TWarehouse wh, string title = null) => PrintPreview(wh?.WarehouseTable, title);
        public void Print(TWarehouse wh, string title = null) => Print(wh?.WarehouseTable, title);

        private void Prepare(DataTable table, string title)
        {
            _table = table;
            _title = string.IsNullOrEmpty(title) ? "Report" : title;
            _currentRow = 0;
            CalculateColumnWidths();

            _headerHeight = (int)Math.Ceiling(_fontHeader.GetHeight() + 8);
            _rowHeight = (int)Math.Ceiling(_fontBody.GetHeight() + 6);
        }

        private void CalculateColumnWidths()
        {
            // Basic proportional column sizing based on header text length and content samples.
            _colWidths = Enumerable.Range(0, _table.Columns.Count).Select(i =>
            {
                string header = _table.Columns[i].ColumnName;
                if (header == "Number") header = "#";
                int sampleLen = header.Length;
                for (int r = 0; r < Math.Min(20, _table.Rows.Count); r++)
                {
                    var v = _table.Rows[r][i];
                    if (v != null)
                    {
                        sampleLen = Math.Max(sampleLen, v.ToString().Length);
                    }
                }
                return Math.Max(5, sampleLen * 5); // rough width per character
            }).ToList();
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            if (_table == null)
            {
                e.HasMorePages = false;
                return;
            }

            var g = e.Graphics;
            Rectangle bounds = e.MarginBounds;
            int x = bounds.Left;
            int y = bounds.Top;

            // Title
            using (var titleFont = new Font(_fontHeader.FontFamily, 14, FontStyle.Bold))
            {
                g.DrawString(_title, titleFont, Brushes.Black, x, y);
                y += (int)Math.Ceiling(titleFont.GetHeight(g)) + 8;
            }

            // Recompute column widths to fit page width preserving proportions
            int totalRequested = _colWidths.Sum();
            int availWidth = bounds.Width;
            var colPixels = _colWidths.Select(w => (int)Math.Floor((double)w / totalRequested * availWidth)).ToList();

            // Ensure no column has zero width and adjust rounding
            for (int i = 0; i < colPixels.Count; i++)
                if (colPixels[i] < 50) colPixels[i] = 50;
            // adjust last column to fill
            int sumCols = colPixels.Sum();
            if (sumCols != availWidth)
            {
                colPixels[colPixels.Count - 1] += (availWidth - sumCols);
            }

            // Column headers background
            int headerX = x;
            for (int c = 0; c < _table.Columns.Count; c++)
            {
                var rc = new Rectangle(headerX, y, colPixels[c], _headerHeight);
                g.FillRectangle(Brushes.LightGray, rc);
                g.DrawRectangle(Pens.Black, rc);
                string text = _table.Columns[c].ColumnName;
                if (text == "Number") text = "#";
                g.DrawString(text, _fontHeader, Brushes.Black, new RectangleF(rc.X + 4, rc.Y + 2, rc.Width - 8, rc.Height - 4));
                headerX += colPixels[c];
            }

            y += _headerHeight;

            // Rows
            while (_currentRow < _table.Rows.Count)
            {
                if (y + _rowHeight > bounds.Bottom)
                {
                    // not enough room: request another page
                    e.HasMorePages = true;
                    return;
                }

                int cellX = x;
                for (int c = 0; c < _table.Columns.Count; c++)
                {
                    var rc = new Rectangle(cellX, y, colPixels[c], _rowHeight);
                    g.DrawRectangle(Pens.DarkGray, rc);

                    string text;
                    var v = _table.Rows[_currentRow][c];
                    if (v == null || v == DBNull.Value) text = string.Empty;
                    else
                    {
                        // format currency/decimal columns nicely
                        if (_table.Columns[c].DataType == typeof(decimal) || _table.Columns[c].DataType == typeof(double) || _table.Columns[c].ColumnName.ToLowerInvariant().Contains("price") || _table.Columns[c].ColumnName.ToLowerInvariant().Contains("total"))
                        {
                            try { text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", Convert.ToDecimal(v)); }
                            catch { text = v.ToString(); }
                        }
                        else if (_table.Columns[c].DataType.IsEnum)
                        {
                            text = Enum.GetName(_table.Columns[c].DataType, v) ?? v.ToString();
                        }
                        else
                        {
                            text = v.ToString();
                        }
                    }

                    var layoutRect = new RectangleF(rc.X + 4, rc.Y + 2, rc.Width - 8, rc.Height - 4);
                    g.DrawString(text, _fontBody, Brushes.Black, layoutRect);
                    cellX += colPixels[c];
                }

                y += _rowHeight;
                _currentRow++;
            }

            // finished
            e.HasMorePages = false;
            // reset row index so subsequent previews/prints start at first row
            _currentRow = 0;
        }

        public void Dispose()
        {
            if (_disposed) return;
            if (_doc != null)
            {
                _doc.PrintPage -= OnPrintPage;
                _doc.Dispose();
                _doc = null;
            }
            _fontBody.Dispose();
            _fontHeader.Dispose();
            _disposed = true;
        }
    }
}
