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

        // Editing state: underlying DataTable row index being edited, -1 = add/new
        private int _editingRowIndex = -1;

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

            // wire new handlers for selection editing and deletion
            WarehouseView.CellDoubleClick += WarehouseView_CellDoubleClick;
            WarehouseView.KeyDown += WarehouseView_KeyDown;

            // create component and wire events
            _searchDropdown = new FuzzySearchDropdown(
                this,
                NameFindTxtBox,
                // search function (pattern -> list of (rowIndex,score))
                _activeWarehouse.FuzzySearchRows,
                // display function for a result index -> shown string
                idx => _activeWarehouse.WarehouseTable.Rows[idx]["Name"]?.ToString() ?? string.Empty,
                // onSelect action: (underlyingIndex, requestEdit)
                OnFuzzySelected
            );


            NameFindTxtBox.KeyDown += _searchDropdown.TextBox_KeyDown;

            InitializeMultiWarehouseSupport();
        }

        // Designer still wires this event — forward to the component.
        private void NameFindTxtBox_TextChanged(object sender, EventArgs e)
        {
            _searchDropdown.ShowFor(NameFindTxtBox.Text);
        }

        private bool ValidColumnValue(string columnName, string value)
        {
            switch (columnName)
            {
                case "Provider":
                    return Enum.TryParse(value, true, out Providers _);
                case "Group":
                    return Enum.TryParse(value, true, out ProductGroup _);
                case "Currency":
                    return Enum.TryParse(value, true, out Currency _);
                case "Units":
                    return Enum.TryParse(value, true, out Units _);
                case "Quantity":
                    return int.TryParse(value, out int _);
                case "Cost":
                    return decimal.TryParse(value, out decimal _);
                case "Total":
                    return decimal.TryParse(value, out decimal _);
                default:
                    return true;
            }
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

            if (ValidColumnValue(colName, val))
            {
                return;
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

            // Build item from header controls
            var groupVal = ProductGroubSelect.SelectedItem;
            ProductGroup group = ProductGroup.Books;
            if (groupVal is ProductGroup g) group = g;
            else if (!Enum.TryParse(ProductGroubSelect.Text, true, out group)) group = ProductGroup.Books;

            var provVal = ProvidedSelect.SelectedItem;
            Providers prov = Providers.ProviderA;
            if (provVal is Providers p) prov = p;
            else if (!Enum.TryParse(ProvidedSelect.Text, true, out prov)) prov = Providers.ProviderA;

            var unitsVal = UnitsSelect.SelectedItem;
            Units units = Units.Piece;
            if (unitsVal is Units u) units = u;
            else if (!Enum.TryParse(UnitsSelect.Text, true, out units)) units = Units.Piece;

            var currVal = CurrencySelect.SelectedItem;
            Currency curr = Currency.USD;
            if (currVal is Currency c) curr = c;
            else if (!Enum.TryParse(CurrencySelect.Text, true, out curr)) curr = Currency.USD;

            WarehouseItem row = new WarehouseItem(
                group,
                ProductNameText.Text,
                ManufacturerName.Text,
                prov,
                units,
                curr,
                quantity,
                cost
            );

            if (_editingRowIndex >= 0 && _editingRowIndex < _activeWarehouse.WarehouseTable.Rows.Count)
            {
                // Update existing DataRow
                try
                {
                    DataRow dr = _activeWarehouse.WarehouseTable.Rows[_editingRowIndex];
                    dr["Group"] = row.Group;
                    dr["Name"] = row.Name;
                    dr["Manufacturer"] = row.Manufacturer;
                    dr["Provider"] = row.Provider;
                    dr["Units"] = row.Units;
                    dr["Currency"] = row.Currency;
                    dr["Quantity"] = row.Quantity;
                    dr["Price"] = row.Price;
                    dr["Total"] = row.Quantity * row.Price;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update row: " + ex.Message);
                }
            }
            else
            {
                _activeWarehouse.AddWarehouseRow(row);
            }
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

        // Called by FuzzySearchDropdown on selection.
        // requestEdit == true -> populate header controls for editing and set editing index.
        // requestEdit == false -> just select the row in the grid.
        private void OnFuzzySelected(int underlyingIndex, bool requestEdit)
        {
            if (requestEdit)
            {
                PopulateHeaderFromUnderlyingIndex(underlyingIndex);
            }
            else
            {
                SelectUnderlyingRow(underlyingIndex);
            }
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
                    OnFuzzySelected
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

        // Populate header controls from a DataGridViewRow's underlying data
        private void PopulateHeaderFromRow(DataGridViewRow dgvRow)
        {
            if (dgvRow == null) return;

            try
            {
                // DataBoundItem should be DataRowView when bound to DataTable/DataView
                var drv = dgvRow.DataBoundItem as DataRowView;
                DataRow sourceRow = drv?.Row;

                // If DataRowView not available, try reading cell values directly
                object gVal = null;
                object nameVal = null;
                object manufVal = null;
                object provVal = null;
                object unitsVal = null;
                object currVal = null;
                object qtyVal = null;
                object priceVal = null;

                if (sourceRow != null)
                {
                    gVal = sourceRow["Group"];
                    nameVal = sourceRow["Name"];
                    manufVal = sourceRow["Manufacturer"];
                    provVal = sourceRow["Provider"];
                    unitsVal = sourceRow["Units"];
                    currVal = sourceRow["Currency"];
                    qtyVal = sourceRow["Quantity"];
                    priceVal = sourceRow["Price"];

                    // compute editing index in underlying table
                    _editingRowIndex = _activeWarehouse.WarehouseTable.Rows.IndexOf(sourceRow);
                }
                else
                {
                    // fallback: read from cells
                    gVal = dgvRow.Cells["Group"].Value;
                    nameVal = dgvRow.Cells["Name"].Value;
                    manufVal = dgvRow.Cells["Manufacturer"].Value;
                    provVal = dgvRow.Cells["Provider"].Value;
                    unitsVal = dgvRow.Cells["Units"].Value;
                    currVal = dgvRow.Cells["Currency"].Value;
                    qtyVal = dgvRow.Cells["Quantity"].Value;
                    priceVal = dgvRow.Cells["Price"].Value;

                    // can't reliably determine underlying DataTable index -> reset editing marker to -1
                    _editingRowIndex = -1;
                }

                // set controls (handle enum/string/int conversions)
                if (gVal != null && gVal != DBNull.Value)
                {
                    TrySetComboBoxFromValue<ProductGroup>(ProductGroubSelect, gVal);
                }

                if (provVal != null && provVal != DBNull.Value)
                {
                    TrySetComboBoxFromValue<Providers>(ProvidedSelect, provVal);
                }

                if (unitsVal != null && unitsVal != DBNull.Value)
                {
                    TrySetComboBoxFromValue<Units>(UnitsSelect, unitsVal);
                }

                if (currVal != null && currVal != DBNull.Value)
                {
                    TrySetComboBoxFromValue<Currency>(CurrencySelect, currVal);
                }

                ProductNameText.Text = nameVal != null && nameVal != DBNull.Value ? nameVal.ToString() : string.Empty;
                ManufacturerName.Text = manufVal != null && manufVal != DBNull.Value ? manufVal.ToString() : string.Empty;

                if (qtyVal != null && qtyVal != DBNull.Value && int.TryParse(qtyVal.ToString(), out int q))
                {
                    if (q < QuantityNumeric.Minimum) q = (int)QuantityNumeric.Minimum;
                    if (q > QuantityNumeric.Maximum) q = (int)QuantityNumeric.Maximum;
                    QuantityNumeric.Value = q;
                }

                CostAmount.Text = priceVal != null && priceVal != DBNull.Value ? priceVal.ToString() : string.Empty;

                // keep button labelled "Update" (renamed per request)
                AddButton.Text = "Update";
            }
            catch
            {
                // ignore errors while populating header
            }
        }

        // New helper: populate header directly from an underlying DataTable row index
        private void PopulateHeaderFromUnderlyingIndex(int underlyingRowIndex)
        {
            if (_activeWarehouse == null) return;
            if (underlyingRowIndex < 0 || underlyingRowIndex >= _activeWarehouse.WarehouseTable.Rows.Count) return;

            var sourceRow = _activeWarehouse.WarehouseTable.Rows[underlyingRowIndex];

            object gVal = sourceRow["Group"];
            object nameVal = sourceRow["Name"];
            object manufVal = sourceRow["Manufacturer"];
            object provVal = sourceRow["Provider"];
            object unitsVal = sourceRow["Units"];
            object currVal = sourceRow["Currency"];
            object qtyVal = sourceRow["Quantity"];
            object priceVal = sourceRow["Price"];

            _editingRowIndex = underlyingRowIndex;

            if (gVal != null && gVal != DBNull.Value)
            {
                TrySetComboBoxFromValue<ProductGroup>(ProductGroubSelect, gVal);
            }

            if (provVal != null && provVal != DBNull.Value)
            {
                TrySetComboBoxFromValue<Providers>(ProvidedSelect, provVal);
            }

            if (unitsVal != null && unitsVal != DBNull.Value)
            {
                TrySetComboBoxFromValue<Units>(UnitsSelect, unitsVal);
            }

            if (currVal != null && currVal != DBNull.Value)
            {
                TrySetComboBoxFromValue<Currency>(CurrencySelect, currVal);
            }

            ProductNameText.Text = nameVal != null && nameVal != DBNull.Value ? nameVal.ToString() : string.Empty;
            ManufacturerName.Text = manufVal != null && manufVal != DBNull.Value ? manufVal.ToString() : string.Empty;

            if (qtyVal != null && qtyVal != DBNull.Value && int.TryParse(qtyVal.ToString(), out int q))
            {
                if (q < QuantityNumeric.Minimum) q = (int)QuantityNumeric.Minimum;
                if (q > QuantityNumeric.Maximum) q = (int)QuantityNumeric.Maximum;
                QuantityNumeric.Value = q;
            }

            CostAmount.Text = priceVal != null && priceVal != DBNull.Value ? priceVal.ToString() : string.Empty;

            AddButton.Text = "Update";
        }

        // Helper: set a ComboBox (bound to Enum.GetValues(enumType)) from a variety of possible source types
        private void TrySetComboBoxFromValue<TEnum>(ComboBox cb, object value) where TEnum : struct
        {
            if (cb == null) return;
            if (value == null || value == DBNull.Value) return;

            if (value is TEnum enumVal)
            {
                cb.SelectedItem = enumVal;
                return;
            }

            // try parse string
            string s = value.ToString();
            if (Enum.TryParse<TEnum>(s, true, out var parsed))
            {
                cb.SelectedItem = parsed;
                return;
            }

            // try numeric conversion
            try
            {
                var underlying = Enum.GetUnderlyingType(typeof(TEnum));
                var conv = Convert.ChangeType(value, underlying);
                var enumObj = Enum.ToObject(typeof(TEnum), conv);
                if (enumObj is TEnum e)
                {
                    cb.SelectedItem = e;
                    return;
                }
            }
            catch { }

            // fallback: do nothing (leave existing selection)
        }

        // Double-click on a row: populate header with its values for editing
        private void WarehouseView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dgv = (DataGridView)sender;
            var row = dgv.Rows[e.RowIndex];
            AddButton.Text = "Update";
            PopulateHeaderFromRow(row);
        }

        // Key handling: Enter to load selected row into header, Delete to remove selected rows with confirmation
        private void WarehouseView_KeyDown(object sender, KeyEventArgs e)
        {
            var dgv = (DataGridView)sender;

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (dgv.CurrentRow != null && dgv.CurrentRow.Index >= 0)
                {
                    PopulateHeaderFromRow(dgv.CurrentRow);
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                // gather selected rows
                var selected = dgv.SelectedRows;
                if (selected == null || selected.Count == 0)
                {
                    // if no full-row selection, try current row
                    if (dgv.CurrentRow != null)
                    {
                        // FIX: Remove attempt to construct DataGridViewSelectedRowCollection
                        var drv = dgv.CurrentRow.DataBoundItem as DataRowView;
                        if (drv == null) return;
                        if (MessageBox.Show($"Delete item '{drv.Row["Name"]}'?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try { drv.Row.Delete(); } catch { }
                        }
                        return;
                    }
                    return;
                }

                int count = selected.Count;
                var confirm = MessageBox.Show($"Delete {count} selected row(s)?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                // Collect DataRowView references first to avoid modifying collection while enumerating selected rows
                var rowsToDelete = new List<DataRowView>();
                foreach (DataGridViewRow r in selected)
                {
                    var drv = r.DataBoundItem as DataRowView;
                    if (drv != null) rowsToDelete.Add(drv);
                }

                foreach (var drv in rowsToDelete)
                {
                    try
                    {
                        drv.Row.Delete();
                    }
                    catch { /* ignore individual failures */ }
                }

                // Reset editing index if the edited row was deleted
                if (_editingRowIndex >= 0)
                {
                    // attempt to clear if row no longer exists
                    if (_editingRowIndex >= _activeWarehouse.WarehouseTable.Rows.Count)
                        _editingRowIndex = -1;
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _editingRowIndex = -1;
            WarehouseView.ClearSelection();
            AddButton.Text = "Add";
        }
    }
}
