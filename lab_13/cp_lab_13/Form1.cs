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
        TWarehouse warehouse = new TWarehouse();
        string filePath;

        // fuzzy dropdown component
        private FuzzySearchDropdown _searchDropdown;

        public Form1()
        {
            InitializeComponent();

            ProductGroubSelect.DataSource = Enum.GetValues(typeof(ProductGroup));
            ProvidedSelect.DataSource = Enum.GetValues(typeof(Providers));
            UnitsSelect.DataSource = Enum.GetValues(typeof(Units));
            CurrencySelect.DataSource = Enum.GetValues(typeof(Currency));

            WarehouseView.DataSource = warehouse.WarehouseTable;

            // configure column headers / widths
            warehouse.SetColumnProperties(WarehouseView);

            // convert enum-typed columns to combo columns
            warehouse.ConvertEnumColumnsToCombo(WarehouseView);

            // handle data errors (invalid combo cell values etc.)
            WarehouseView.DataError += WarehouseView_DataError;
            
            // create component and wire events
            _searchDropdown = new FuzzySearchDropdown(
                this,
                NameFindTxtBox,
                // search function (pattern -> list of (rowIndex,score))
                warehouse.FuzzySearchRows,
                // display function for a result index -> shown string
                idx => warehouse.WarehouseTable.Rows[idx]["Name"]?.ToString() ?? string.Empty,
                // onSelect action: select underlying row in the grid
                SelectUnderlyingRow
            );

            NameFindTxtBox.KeyDown += _searchDropdown.TextBox_KeyDown;
        }

        // Designer still wires this event — forward to the component.
        private void NameFindTxtBox_TextChanged(object sender, EventArgs e)
        {
            _searchDropdown.ShowFor(NameFindTxtBox.Text);
        }

        // DataError handler prevents the DataGridView from throwing on invalid combo values
        private void WarehouseView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
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
                quantity,
                cost
            );

            warehouse.AddWarehouseRow(row);
        }

        private string LoadFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\Users\\1\\Documents\\";
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return string.Empty;
        }

        private void SaveAsCSVBtn_Click(object sender, EventArgs e)
        {
            filePath = LoadFile();

            warehouse.SaveTableToFile(filePath);
        }

        private void LoadCSVBtn_Click(object sender, EventArgs e)
        {
            filePath = LoadFile();

            warehouse.ReadTableFromFile(filePath, SummaryView);
        }

        private void SaveCSVBtn_Click(object sender, EventArgs e)
        {
            if (filePath.Equals(string.Empty))
            {
                filePath = LoadFile();
            }

            warehouse.SaveTableToFile(filePath);
        }

        private void SelectUnderlyingRow(int underlyingRow)
        {
            try
            {
                // try direct selection by underlying row index
                if (underlyingRow >= 0 && underlyingRow < WarehouseView.Rows.Count)
                {
                    WarehouseView.FirstDisplayedCell = WarehouseView.Rows[underlyingRow].Cells["Name"];
                    WarehouseView.Rows[underlyingRow].Selected = true;
                    WarehouseView.CurrentCell = WarehouseView.Rows[underlyingRow].Cells["Name"];
                    return;
                }

                // fallback: find by Name value
                string name = warehouse.WarehouseTable.Rows[underlyingRow]["Name"]?.ToString();
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
            catch
            {
                // ignore selection errors
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

            warehouse.ApplyFilter(filter, SummaryView);
        }

        private void sortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sorting = SortTxtBox.Text;

            warehouse.ApplySort(sorting, WarehouseView, SummaryView);
        }
    }
}
