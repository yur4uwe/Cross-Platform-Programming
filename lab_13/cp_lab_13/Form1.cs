using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cp_lab_13
{
    public partial class Form1 : Form
    {
        string filePath;

        // fuzzy dropdown component
        private FuzzySearchDropdown _searchDropdown;

        private WarehouseManager _warehouseManager = new WarehouseManager();
        private TWarehouse _activeWarehouse;

        public Form1()
        {
            InitializeComponent();

            ProductGroubSelect.DataSource = Enum.GetValues(typeof(ProductGroup));
            ProvidedSelect.DataSource = Enum.GetValues(typeof(Providers));
            UnitsSelect.DataSource = Enum.GetValues(typeof(Units));
            CurrencySelect.DataSource = Enum.GetValues(typeof(Currency));

            if (_warehouseManager.Warehouses.Count == 0)
            {
                var defaultWarehouse = new TWarehouse();
                _activeWarehouse = defaultWarehouse;
                _warehouseManager["Default Warehouse"] = defaultWarehouse;
            }

            WarehouseView.DataSource = _activeWarehouse.WarehouseTable;

            // configure column headers / widths
            _activeWarehouse.SetColumnProperties(WarehouseView);

            // convert enum-typed columns to combo columns
            _activeWarehouse.ConvertEnumColumnsToCombo(WarehouseView);

            // create component and wire events
            _searchDropdown = new FuzzySearchDropdown(
                this,
                NameFindTxtBox,
                // search function (pattern -> list of (rowIndex,score))
                _activeWarehouse.FuzzySearchRows,
                // display function for a result index -> shown string
                idx => _activeWarehouse.WarehouseTable.Rows[idx]["Name"]?.ToString() ?? string.Empty,
                // onSelect action: select underlying row in the grid
                SelectUnderlyingRow
            );

            NameFindTxtBox.KeyDown += _searchDropdown.TextBox_KeyDown;

            InitializeMultiWarehouseSupport();
        }

        // Designer still wires this event — forward to the component.
        private void NameFindTxtBox_TextChanged(object sender, EventArgs e)
        {
            _searchDropdown.ShowFor(NameFindTxtBox.Text);
        }

        // DataError handler prevents the DataGridView from throwing on invalid combo values
        private void WarehouseView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string colName = dgv.Columns[e.ColumnIndex].Name;

            string val = cell.Value.ToString() ?? string.Empty;

            e.Cancel = true;
            e.ThrowException = false;

            switch (colName)
            {
                case "Provider":
                    if (Enum.TryParse(val, true, out Providers _))
                        return;
                    break;
                case "Group":
                    if (Enum.TryParse(val, true, out ProductGroup _))
                        return;
                    break;
                case "Currency":
                    if (Enum.TryParse(val, true, out Currency _))
                        return;
                    break;
                case "Units":
                    if (Enum.TryParse(val, true, out Units _))
                        return;
                    break;
            }

            e.Cancel = false;
            MessageBox.Show($"Invalid data on column {e.ColumnIndex} row {e.RowIndex} with value '{val}'");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(CostAmount.Text, out decimal cost))
            {
                MessageBox.Show("Invalid cost amount");
                return;
            }

            if (!int.TryParse(QuantityNumeric.Text, out int quantity))
            {
                MessageBox.Show("Invalid quantity");
                return;
            }

            if (ProductNameText.Text.Contains(",") ||
                ManufacturerName.Text.Contains(","))
            {
                MessageBox.Show("Input fields cannot contain commas");
            }


            WarehouseItem row = new WarehouseItem(
                (ProductGroup)ProductGroubSelect.SelectedIndex,
                ProductNameText.Text,
                ManufacturerName.Text,
                (Providers)ProvidedSelect.SelectedIndex,
                (Units)UnitsSelect.SelectedIndex,
                (Currency)CurrencySelect.SelectedIndex,
                quantity,
                cost
            );

            _activeWarehouse.AddWarehouseRow(row);
        }

        private string LoadFile(bool save)
        {
            FileDialog dialog;
            if (save)
            {
                dialog = new SaveFileDialog();
            }
            else
            {
                dialog = new OpenFileDialog();
            }

            dialog.InitialDirectory = "c:\\Users\\1\\Documents\\";
            dialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return string.Empty;
        }

        private void SaveAsCSVBtn_Click(object sender, EventArgs e)
        {
            filePath = LoadFile(true);

            _activeWarehouse.SaveTableToFile(filePath);
        }

        private void LoadCSVBtn_Click(object sender, EventArgs e)
        {
            filePath = LoadFile(false);

            if (filePath.Equals(string.Empty))
            {
                return;
            }

            var wh = new TWarehouse();
            wh.ReadTableFromFile(filePath, SummaryView);

            _warehouseManager[filePath] = wh;

            _warehouseManager.RemoveWarehouse("Default Warehouse");

            SetActiveWarehouse(wh);
        }

        private void SaveCSVBtn_Click(object sender, EventArgs e)
        {
            if (filePath.Equals(string.Empty))
            {
                filePath = LoadFile(true);
            }

            if (filePath.Equals(string.Empty))
            {
                return;
            }

            _activeWarehouse.SaveTableToFile(filePath);
        }

        private void SelectUnderlyingRow(int underlyingRow)
        {
            try
            {
                if (underlyingRow >= 0 && underlyingRow < WarehouseView.Rows.Count)
                {
                    WarehouseView.FirstDisplayedCell = WarehouseView.Rows[underlyingRow].Cells["Name"];
                    WarehouseView.Rows[underlyingRow].Selected = true;
                    WarehouseView.CurrentCell = WarehouseView.Rows[underlyingRow].Cells["Name"];
                    return;
                }

                string name = _activeWarehouse.WarehouseTable.Rows[underlyingRow]["Name"]?.ToString();
                for (int i = 0; i < WarehouseView.Rows.Count; i++)
                {
                    if (WarehouseView.Rows[i].Cells["Name"].Value != null &&
                        WarehouseView.Rows[i].Cells["Name"].Value.ToString() == name)
                    {
                        WarehouseView.FirstDisplayedCell = WarehouseView.Rows[i].Cells["Name"];
                        WarehouseView.Rows[i].Selected = true;
                        WarehouseView.CurrentCell = WarehouseView.Rows[i].Cells["Name"];
                        return;
                    }
                }
            }
            catch { }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _searchDropdown?.Dispose();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            var filter = ItemFilterTxtBox.Text;

            _activeWarehouse.ApplyFilter(filter, WarehouseView);
        }

        private void sortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sorting = SortTxtBox.Text;

            _activeWarehouse.ApplySort(sorting, WarehouseView, SummaryView);
        }

        private void InitializeMultiWarehouseSupport()
        {
            PopulateWarehouseTree();
            _warehouseManager.WarehousesChanged += PopulateWarehouseTree;

            if (_warehouseManager.Warehouses.Count > 0)
                SetActiveWarehouse(_warehouseManager.Warehouses[0]);
        }

        private void PopulateWarehouseTree()
        {
            WarehouseTreeView.BeginUpdate();
            WarehouseTreeView.Nodes.Clear();

            foreach (var wh in _warehouseManager.Warehouses)
            {
                string name = wh.WarehouseTable.ExtendedProperties["Name"] as string ?? "Warehouse";
                var root = new TreeNode(name) { Tag = wh };

                foreach (ProductGroup pg in Enum.GetValues(typeof(ProductGroup)))
                {
                    var n = new TreeNode(pg.ToString()) { Tag = pg };
                    root.Nodes.Add(n);
                }
                WarehouseTreeView.Nodes.Add(root);
            }

            WarehouseTreeView.EndUpdate();
            WarehouseTreeView.ExpandAll();
        }

        private void WarehousesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            if (e.Node.Tag is TWarehouse wh)
            {
                SetActiveWarehouse(wh);
            }
            else if (e.Node.Parent != null && e.Node.Tag is ProductGroup pg && e.Node.Parent.Tag is TWarehouse parentWh)
            {
                SetActiveWarehouse(parentWh, pg);
            }
        }

        private void SetActiveWarehouse(TWarehouse wh, ProductGroup? focusGroup = null)
        {
            if (wh == null) return;
            _activeWarehouse = wh;
            WarehouseView.DataSource = _activeWarehouse.WarehouseTable;
            _activeWarehouse.SetColumnProperties(WarehouseView);
            _activeWarehouse.ConvertEnumColumnsToCombo(WarehouseView);

            if (_searchDropdown != null)
            {
                _searchDropdown.UpdateBindings(
                    _activeWarehouse.FuzzySearchRows,
                    idx => _activeWarehouse.WarehouseTable.Rows[idx]["Name"]?.ToString() ?? string.Empty,
                    SelectUnderlyingRow
                );
            }

            if (focusGroup.HasValue)
            {
                // Build a RowFilter that compares the same underlying type the column stores.
                var col = _activeWarehouse.WarehouseTable.Columns["Group"];
                string filter;
                if (col != null && col.DataType != null && col.DataType.IsEnum)
                {
                    // Enum column stores integer values — compare using numeric literal
                    filter = $"Group = {(int)focusGroup.Value}";
                }
                else
                {
                    // Fallback: compare string name (escape single quotes)
                    var name = focusGroup.Value.ToString().Replace("'", "''");
                    filter = $"Group = '{name}'";
                }

                var dv = new DataView(_activeWarehouse.WarehouseTable)
                {
                    RowFilter = filter
                };
                WarehouseView.DataSource = dv;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeWarehouse.ClearFilters(WarehouseView);
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            var printer = new TablePrinter(this);
            printer.PrintPreview(_activeWarehouse, "Warehouse Report");
        }

        private void totalValuePerGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveStatistics(_activeWarehouse.GetTotalValuePerGroup());
        }

        private void lowInStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveStatistics(_activeWarehouse.GetLowStockProducts());
        }

        private void totalValuePerProviderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveStatistics(_activeWarehouse.GetTotalValuePerProvider());
        }

        private void averagePricePerGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveStatistics(_activeWarehouse.GetAveragePricePerGroup());
        }

        private void unitsDistributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveStatistics(_activeWarehouse.GetUnitsDistribution());
        }

        private void SaveStatistics<Tkey, TValue>(Dictionary<Tkey, TValue> d)
        {
            if (d == null || d.Count == 0)
            {
                MessageBox.Show("No data to export");
                return;
            }

            var pathToSave = LoadFile(true);
            if (pathToSave.Equals(string.Empty))
            {
                return;
            }

            _activeWarehouse.ExportStatsToCsv(d, pathToSave);
            MessageBox.Show("Statistics saved successfully", "Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
