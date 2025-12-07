using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cp_lab_13
{
    public class WarehouseItem
    {
        public ProductGroup Group;
        public string Name;
        public string Manufacturer;
        public Providers Provider;
        public Units Units;
        public Currency Currency;
        public decimal Price;
        public int Quantity;
        public WarehouseItem(ProductGroup group, string name, string manufacturer, Providers provider, Units units, Currency curr,
                             int quantity, decimal price)
        {
            Group = group;
            Name = name;
            Manufacturer = manufacturer;
            Quantity = quantity;
            Price = price;
            Provider = provider;
            Units = units;
            Currency = curr;
        }
    }

    public class TWarehouse
    {
        // Main warehouse table
        public DataTable WarehouseTable = new DataTable();

        // DataView for filtering and sorting
        public DataView WarehouseView;

        // Filter and sort criteria storage
        public string FilterCriteria;
        public string SortCriteria;

        // Reference table for product groups
        public DataTable GroupReference = new DataTable();

        // ComboBox column for groups
        public DataGridViewComboBoxColumn GroupComboColumn;

        // Constructor - creates table structure
        public TWarehouse()
        {
            WarehouseTable.Columns.Add(new DataColumn("Number", typeof(int)));
            WarehouseTable.Columns.Add(new DataColumn("Group", typeof(ProductGroup)));
            WarehouseTable.Columns.Add(new DataColumn("Name", typeof(string)));
            WarehouseTable.Columns.Add(new DataColumn("Manufacturer", typeof(string)));
            WarehouseTable.Columns.Add(new DataColumn("Provider", typeof(Providers)));
            WarehouseTable.Columns.Add(new DataColumn("Units", typeof(Units)));
            WarehouseTable.Columns.Add(new DataColumn("Currency", typeof(Currency)));
            WarehouseTable.Columns.Add(new DataColumn("Quantity", typeof(int)));
            WarehouseTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
            WarehouseTable.Columns.Add(new DataColumn("Total", typeof(decimal)));

            // Create DataView for filtering and sorting
            WarehouseView = new DataView(WarehouseTable);
        }

        // Method to add new row to warehouse table
        public void AddWarehouseRow(WarehouseItem w)
        {
            DataRow newRow = WarehouseTable.NewRow();

            newRow["Number"] = WarehouseTable.Rows.Count + 1;
            newRow["Group"] = w.Group;
            newRow["Name"] = w.Name;
            newRow["Manufacturer"] = w.Manufacturer;
            newRow["Provider"] = w.Provider;
            newRow["Units"] = w.Units;
            newRow["Quantity"] = w.Quantity;
            newRow["Currency"] = w.Currency;
            newRow["Price"] = w.Price;
            newRow["Total"] = w.Quantity * w.Price;

            WarehouseTable.Rows.Add(newRow);
        }

        // Set column properties for DataGridView
        public void SetColumnProperties(DataGridView dgv)
        {
            dgv.Columns["Number"].HeaderText = "No.";
            dgv.Columns["Number"].Width = 50;
            dgv.Columns["Group"].HeaderText = "Group";
            dgv.Columns["Group"].Width = 120;
            dgv.Columns["Name"].HeaderText = "Product Name";
            dgv.Columns["Name"].Width = 200;
            dgv.Columns["Manufacturer"].HeaderText = "Manufacturer";
            dgv.Columns["Manufacturer"].Width = 150;
            dgv.Columns["Quantity"].HeaderText = "Quantity";
            dgv.Columns["Quantity"].Width = 80;
            dgv.Columns["Price"].HeaderText = "Price";
            dgv.Columns["Price"].Width = 100;
            dgv.Columns["Total"].HeaderText = "Total Value";
            dgv.Columns["Total"].Width = 120;
        }

        // New helper: ensure any string/int values in enum columns are converted to actual enum values
        public void NormalizeEnumColumnValues()
        {
            var enumCols = WarehouseTable.Columns
                .OfType<DataColumn>()
                .Where(c => c.DataType != null && c.DataType.IsEnum)
                .ToList();

            foreach (var dc in enumCols)
            {
                for (int r = 0; r < WarehouseTable.Rows.Count; r++)
                {
                    var val = WarehouseTable.Rows[r][dc];
                    if (val == null || val == DBNull.Value)
                        continue;

                    // if already the correct enum type, continue
                    if (val.GetType() == dc.DataType)
                        continue;

                    // if it's a string that names the enum, parse it
                    if (val is string s)
                    {
                        try
                        {
                            // case-insensitive parse
                            object parsed = Enum.Parse(dc.DataType, s, true);
                            WarehouseTable.Rows[r][dc] = parsed;
                            continue;
                        }
                        catch
                        {
                            // fall through and try numeric parse
                        }
                    }

                    // if it's numeric (stringified or other), try convert to underlying type then to enum
                    try
                    {
                        var underlying = Enum.GetUnderlyingType(dc.DataType);
                        object conv = Convert.ChangeType(val, underlying);
                        object enumObj = Enum.ToObject(dc.DataType, conv);
                        WarehouseTable.Rows[r][dc] = enumObj;
                    }
                    catch
                    {
                        // leave value as-is (will be treated later); do not throw
                    }
                }
            }
        }

        // ensure the DataGridView column at columnName is a ComboBox bound to enumValues (if already correct, no-op)
        private void EnsureColumnIsCombo(DataGridView dgv, string columnName, Type enumType)
        {
            if (dgv == null || !dgv.Columns.Contains(columnName)) return;

            var existing = dgv.Columns[columnName];
            // already a properly typed combo column -> nothing to do
            if (existing is DataGridViewComboBoxColumn existingCombo &&
                existingCombo.ValueType == enumType)
            {
                return;
            }

            // preserve visual properties
            string header = existing.HeaderText;
            int width = existing.Width;
            int displayIndex = existing.DisplayIndex;

            // create combo column using actual enum values (not names)
            var combo = new DataGridViewComboBoxColumn
            {
                DataPropertyName = columnName,
                Name = columnName,
                HeaderText = header,
                ValueType = enumType,
                DataSource = Enum.GetValues(enumType),
                FlatStyle = FlatStyle.Flat,
                Width = width,
                MaxDropDownItems = 12,
                DisplayIndex = displayIndex,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
            };

            // replace column
            dgv.Columns.Remove(columnName);
            int insertIndex = Math.Min(displayIndex, dgv.Columns.Count);
            dgv.Columns.Insert(insertIndex, combo);
        }

        // Ensure a DataGridView cell value is an actual enum value that matches combo items.
        private void EnsureCellEnumMatch(DataGridViewCell cell, Type enumType)
        {
            if (cell == null || enumType == null) return;
            var val = cell.Value;
            if (val == null || val == DBNull.Value) return;

            // If already same enum type, we're good
            if (val.GetType() == enumType) return;

            // Try parse string -> enum (case-insensitive)
            try
            {
                var parsed = Enum.Parse(enumType, val.ToString(), true);
                cell.Value = parsed;
                return;
            }
            catch { }

            // Try convert numeric -> enum
            try
            {
                var underlying = Enum.GetUnderlyingType(enumType);
                var conv = Convert.ChangeType(val, underlying);
                var enumObj = Enum.ToObject(enumType, conv);
                cell.Value = enumObj;
                return;
            }
            catch { }

            // fallback: set to first enum value to avoid invalid-cell exception
            var first = Enum.GetValues(enumType).GetValue(0);
            cell.Value = first;
        }

        // New: convert enum-typed columns into DataGridViewComboBoxColumn
        public void ConvertEnumColumnsToCombo(DataGridView dgv)
        {
            if (dgv == null) return;

            // collect enum columns to convert
            var enumCols = WarehouseTable.Columns
                .OfType<DataColumn>()
                .Where(c => c.DataType != null && c.DataType.IsEnum)
                .ToList();

            foreach (var dc in enumCols)
            {
                if (!dgv.Columns.Contains(dc.ColumnName))
                    continue;

                // replace/ensure the column is a combo of the proper enum type
                EnsureColumnIsCombo(dgv, dc.ColumnName, dc.DataType);

                // After column exists as combo, coerce any displayed cell values
                foreach (DataGridViewRow dgvr in dgv.Rows)
                {
                    if (dgvr.IsNewRow) continue;
                    var cell = dgvr.Cells[dc.ColumnName];
                    EnsureCellEnumMatch(cell, dc.DataType);
                }
            }

            dgv.Refresh();
        }

        // Save table to a file
        public void SaveTableToFile(string fileName)
        {
            try
            {
                var sw = new StreamWriter(fileName);
                foreach (DataRow row in WarehouseTable.Rows)
                {
                    string textRow = string.Join(",",
                        row["Group"].ToString(),
                        row["Name"].ToString(),
                        row["Manufacturer"].ToString(),
                        row["Provider"].ToString(),
                        row["Units"].ToString(),
                        row["Currency"].ToString(),
                        row["Quantity"].ToString(),
                        row["Price"].ToString()
                    );
                    sw.WriteLine(textRow);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Table was not saved: " + e.Message);
            }
        }

        // Read table from a file
        public void ReadTableFromFile(string fileName, DataGridView dgvSum)
        {
            WarehouseTable.Rows.Clear();

            if (!File.Exists(fileName))
            {
                MessageBox.Show("File does not exist");
                return;
            }

            try
            {
                StreamReader sr = new StreamReader(fileName);
                int rowNumber = 0;

                while (sr.Peek() >= 0)
                {
                    rowNumber++;
                    string textRow = sr.ReadLine();

                    string[] parts = textRow.Split(',');

                    if (parts.Length != 8)
                    {
                        MessageBox.Show($"Invalid data format in file on row {rowNumber}");
                        continue;
                    }

                    if (!int.TryParse(parts[6], out int quantity))
                    {
                        MessageBox.Show($"Invalid quantity in file on row {rowNumber}");
                        continue;
                    }
                    if (!decimal.TryParse(parts[7], out decimal price))
                    {
                        MessageBox.Show($"Invalid price in file on row {rowNumber}");
                        continue;
                    }
                    if (!Enum.TryParse(parts[0], true, out ProductGroup group))
                    {
                        MessageBox.Show($"Invalid product group in file on row {rowNumber}");
                        continue;
                    }
                    if (!Enum.TryParse(parts[3], true, out Providers provider))
                    {
                        MessageBox.Show($"Invalid provider in file on row {rowNumber}");
                        continue;
                    }
                    if (!Enum.TryParse(parts[4], true, out Units units))
                    {
                        MessageBox.Show($"Invalid units in file on row {rowNumber}");
                        continue;
                    }
                    if (!Enum.TryParse(parts[5], true, out Currency currency))
                    {
                        MessageBox.Show($"Invalid currency in file on row {rowNumber}");
                        continue;
                    }


                    WarehouseItem row = new WarehouseItem(
                        group,
                        parts[1],
                        parts[2],
                        provider,
                        units,
                        currency,
                        quantity,
                        price
                    );

                    AddWarehouseRow(row);
                }

                sr.Close();

                SetSummaryTransposed(dgvSum);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading file: " + e.Message);
            }
        }

        // Apply filter to table
        public void ApplyFilter(string filter, DataGridView dgv)
        {
            try
            {
                WarehouseView.RowFilter = filter;
                FilterCriteria = filter;
                dgv.DataSource = WarehouseView;
            }
            catch
            {
                MessageBox.Show("The filter you entered is invalid");
                return;
            }
        }

        // Apply sorting to table
        public void ApplySort(string sort, DataGridView dgv, DataGridView dgvSum)
        {
            try
            {
                WarehouseView.Sort = sort;
                SortCriteria = sort;
                dgv.DataSource = WarehouseView;
                dgv.Refresh();
            }
            catch
            {
                MessageBox.Show("The sort criteria you entered is invalid");
                return;
            }
        }

        // Search for product by exact name
        public void SearchByNameExact(string searchName, DataGridView dgv)
        {
            int foundRow = -1;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["Name"].Value != null &&
                    (string)dgv.Rows[i].Cells["Name"].Value == searchName)
                {
                    foundRow = i;
                    break;
                }
            }

            if (foundRow >= 0)
            {
                dgv.FirstDisplayedCell = dgv.Rows[foundRow].Cells["Name"];
                dgv.Rows[foundRow].Selected = true;
                dgv.CurrentCell = dgv.Rows[foundRow].Cells["Name"];
            }
            else
            {
                MessageBox.Show("Product not found");
            }
        }

        // Simple fuzzy match similar to VSCode's basic file-fuzzy heuristics.
        // Returns true if all characters of 'pattern' can be found in order inside 'candidate'.
        // Also computes a score (higher = better). Score prefers:
        //  - prefix matches
        //  - matches at word boundaries or after non-alphanumeric
        //  - consecutive matches
        // Use case-insensitive matching.
        public bool FuzzyMatch(string pattern, string candidate, out int score)
        {
            score = 0;
            if (string.IsNullOrEmpty(pattern))
            {
                score = 0;
                return true;
            }
            if (string.IsNullOrEmpty(candidate))
            {
                return false;
            }

            string p = pattern.ToLowerInvariant();
            string s = candidate.ToLowerInvariant();

            int pi = 0;
            int si = 0;
            int totalScore = 0;
            int consecutive = 0;
            int firstMatchIndex = -1;

            while (pi < p.Length && si < s.Length)
            {
                if (p[pi] == s[si])
                {
                    // base score for matching a character
                    int charScore = 10;

                    // prefix bonus
                    if (si == 0)
                        charScore += 25;

                    // word boundary bonus (previous char non-alnum) or camel case (previous lowercase, current uppercase in original)
                    if (si > 0)
                    {
                        char prev = candidate[si - 1];
                        if (!char.IsLetterOrDigit(prev))
                            charScore += 15;
                        else
                        {
                            // camelCase bonus approximated by checking original candidate char
                            char curOrig = candidate[si];
                            char prevOrig = candidate[si - 1];
                            if (char.IsLower(prevOrig) && char.IsUpper(curOrig))
                                charScore += 12;
                        }
                    }

                    // consecutive match bonus
                    if (consecutive > 0)
                        charScore += consecutive * 8;

                    totalScore += charScore;
                    consecutive++;
                    if (firstMatchIndex == -1) firstMatchIndex = si;
                    pi++;
                }
                else
                {
                    consecutive = 0;
                }
                si++;
            }

            bool matched = (pi == p.Length);
            if (!matched)
            {
                score = 0;
                return false;
            }

            // penalty for late matches (long prefix skipped)
            if (firstMatchIndex > 0)
                totalScore -= firstMatchIndex * 2;

            // small penalty for very long candidate strings
            totalScore -= (s.Length - pattern.Length) / 5;

            // ensure non-negative
            score = Math.Max(0, totalScore);
            return true;
        }

        // Return matching row indices and scores ordered by score desc.
        public List<Tuple<int, int>> FuzzySearchRows(string pattern)
        {
            var results = new List<Tuple<int, int>>();

            for (int i = 0; i < WarehouseTable.Rows.Count; i++)
            {
                var val = WarehouseTable.Rows[i]["Name"];
                if (val == null) continue;
                string name = val.ToString();
                if (FuzzyMatch(pattern, name, out int score))
                {
                    if (score > 0)
                        results.Add(Tuple.Create(i, score));
                }
            }

            // order by score descending, then by row index ascending
            results.Sort((a, b) =>
            {
                int cmp = b.Item2.CompareTo(a.Item2);
                if (cmp != 0) return cmp;
                return a.Item1.CompareTo(b.Item1);
            });

            return results;
        }

        // Select best fuzzy match in the provided DataGridView.
        // If none found shows a message.
        public void SearchByName(string pattern, DataGridView dgv)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                MessageBox.Show("Enter search text");
                return;
            }

            var matches = FuzzySearchRows(pattern);
            if (matches.Count == 0)
            {
                MessageBox.Show("No fuzzy matches found");
                return;
            }

            int bestRowIndex = matches[0].Item1;

            // attempt to select the corresponding displayed row in dgv
            if (bestRowIndex >= 0 && bestRowIndex < dgv.Rows.Count)
            {
                dgv.FirstDisplayedCell = dgv.Rows[bestRowIndex].Cells["Name"];
                dgv.Rows[bestRowIndex].Selected = true;
                dgv.CurrentCell = dgv.Rows[bestRowIndex].Cells["Name"];
            }
            else
            {
                // If DataGridView uses a DataView or different ordering, try to find the row by comparing Name value
                string bestName = WarehouseTable.Rows[bestRowIndex]["Name"].ToString();
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells["Name"].Value != null &&
                        dgv.Rows[i].Cells["Name"].Value.ToString() == bestName)
                    {
                        dgv.FirstDisplayedCell = dgv.Rows[i].Cells["Name"];
                        dgv.Rows[i].Selected = true;
                        dgv.CurrentCell = dgv.Rows[i].Cells["Name"];
                        return;
                    }
                }
                MessageBox.Show("Match found in underlying data but not visible in grid (different view/filter).");
            }
        }

        // Calculate and display summary
        public void SetSummary(DataGridView dgv)
        {
            string currentGroup;
            string savedSort;
            decimal groupTotal;
            int i;

            DataTable summaryTable = new DataTable();

            // Fixed: use DataColumn (not DataRow) and set types correctly
            DataColumn cGroup = new DataColumn("Group", typeof(string));
            DataColumn cTotal = new DataColumn("Total Value", typeof(decimal));

            summaryTable.Columns.Add(cGroup);
            summaryTable.Columns.Add(cTotal);

            savedSort = WarehouseView.Sort;
            WarehouseView.Sort = "Group";

            i = 0;
            while (i < WarehouseView.Count)
            {
                currentGroup = (string)WarehouseView[i]["Group"];
                groupTotal = 0.0M;

                while ((i < WarehouseView.Count) &&
                       (currentGroup == (string)WarehouseView[i]["Group"]))
                {
                    try
                    {
                        groupTotal += (decimal)WarehouseView[i]["Total"];
                    }
                    catch
                    {
                        WarehouseView[i]["Total"] = 0M;
                    }
                    i++;
                    if (i == WarehouseView.Count) { break; }
                }

                DataRow summaryRow = summaryTable.NewRow();
                summaryRow["Group"] = currentGroup;
                summaryRow["Total Value"] = groupTotal;
                summaryTable.Rows.Add(summaryRow);
            }

            dgv.DataSource = summaryTable;
            WarehouseView.Sort = SortCriteria;
        }

        // Calculate and display summary transposed:
        // first column = "Metric", subsequent columns = group names,
        // single row with metric "Total Value" and each group's total as a cell.
        public void SetSummaryTransposed(DataGridView dgv)
        {
            // Build totals per group
            var totals = new Dictionary<string, decimal>(StringComparer.Ordinal);
            foreach (DataRow r in WarehouseTable.Rows)
            {
                string group = Enum.GetName(typeof(ProductGroup), r["Group"]) ?? "";
                decimal total;
                try
                {
                    // prefer stored Total column when present
                    if (r["Total"] != DBNull.Value)
                        total = Convert.ToDecimal(r["Total"]);
                    else
                        total = Convert.ToDecimal(r["Quantity"]) * Convert.ToDecimal(r["Price"]);
                }
                catch
                {
                    total = 0M;
                }

                if (totals.ContainsKey(group))
                    totals[group] += total;
                else
                    totals[group] = total;
            }

            // Prepare transposed DataTable
            DataTable t = new DataTable();
            t.Columns.Add(new DataColumn("Metric", typeof(string)));

            // Add a column for each group
            foreach (var group in totals.Keys)
            {
                // column names must be unique and valid
                t.Columns.Add(new DataColumn(group, typeof(decimal)));
            }

            // Single metric row (you can add more metric rows if needed)
            DataRow metricRow = t.NewRow();
            metricRow["Metric"] = "Total Value";
            foreach (var kv in totals)
            {
                metricRow[kv.Key] = kv.Value;
            }
            t.Rows.Add(metricRow);

            dgv.DataSource = t;
        }

        // Create reference table for product groups
        public void CreateGroupReference()
        {
            DataColumn cGroup = new DataColumn("Group");
            cGroup.DataType = Type.GetType("System.String");
            GroupReference.Columns.Add(cGroup);

            string[] groups = Enum.GetNames(typeof(ProductGroup));

            foreach (string group in groups)
            {
                DataRow row = GroupReference.NewRow();
                row[cGroup] = group;
                GroupReference.Rows.Add(row);
            }
        }

        // Add or replace this method: create a combo column that uses enum values (not string names)
        public void AddGroupComboColumn(DataGridView dgv)
        {
            if (dgv == null) return;
            if (!dgv.Columns.Contains("Group")) return;

            // Ensure Group column is a properly-typed combo column
            EnsureColumnIsCombo(dgv, "Group", typeof(ProductGroup));

            // Coerce existing cell values to enum instances so they match combo items
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (dgvr.IsNewRow) continue;
                var cell = dgvr.Cells["Group"];
                EnsureCellEnumMatch(cell, typeof(ProductGroup));
            }

            dgv.Refresh();
        }

        public void ClearFilters(DataGridView dgv)
        {
            WarehouseView.RowFilter = string.Empty;
            FilterCriteria = string.Empty;
            dgv.DataSource = WarehouseView;
            dgv.Refresh();
        }

        public Dictionary<ProductGroup, decimal> GetTotalValuePerGroup()
        {
            var totals = new Dictionary<ProductGroup, decimal>();
            foreach (DataRow r in WarehouseTable.Rows)
            {
                try
                {
                    var grpObj = r["Group"];
                    if (grpObj == DBNull.Value) continue;
                    var grp = (ProductGroup)grpObj;
                    decimal rowTotal = 0M;
                    if (r["Total"] != DBNull.Value)
                        rowTotal = Convert.ToDecimal(r["Total"]);
                    else
                        rowTotal = Convert.ToDecimal(r["Quantity"]) * Convert.ToDecimal(r["Price"]);

                    if (totals.ContainsKey(grp)) totals[grp] += rowTotal;
                    else totals[grp] = rowTotal;
                }
                catch { /* skip malformed row */ }
            }
            return totals;
        }

        public Dictionary<string, int> GetLowStockProducts()
        {
            var low = new Dictionary<string, int>();
            foreach (DataRow r in WarehouseTable.Rows)
            {
                try
                {
                    string name = r["Name"] == DBNull.Value ? string.Empty : r["Name"].ToString();
                    int qty = r["Quantity"] != DBNull.Value ? Convert.ToInt32(r["Quantity"]) : 0;
                    if (qty <= 5) low[name] = qty;
                }
                catch { }
            }
            return low.OrderBy(t => t.Value).ToDictionary(t => t.Key, t => t.Value);
        }

        public Dictionary<Providers, decimal> GetTotalValuePerProvider()
        {
            var totals = new Dictionary<Providers, decimal>();
            foreach (DataRow r in WarehouseTable.Rows)
            {
                try
                {
                    var provObj = r["Provider"];
                    if (provObj == DBNull.Value) continue;
                    var prov = (Providers)provObj;
                    decimal rowTotal = r["Total"] != DBNull.Value ? Convert.ToDecimal(r["Total"]) :
                                       Convert.ToDecimal(r["Quantity"]) * Convert.ToDecimal(r["Price"]);

                    if (totals.ContainsKey(prov)) totals[prov] += rowTotal;
                    else totals[prov] = rowTotal;
                }
                catch { }
            }
            return totals;
        }

        public Dictionary<ProductGroup, decimal> GetAveragePricePerGroup()
        {
            var sums = new Dictionary<ProductGroup, decimal>();
            var counts = new Dictionary<ProductGroup, int>();
            foreach (DataRow r in WarehouseTable.Rows)
            {
                try
                {
                    var grpObj = r["Group"];
                    if (grpObj == DBNull.Value) continue;
                    var grp = (ProductGroup)grpObj;
                    decimal price = r["Price"] != DBNull.Value ? Convert.ToDecimal(r["Price"]) : 0M;
                    if (counts.ContainsKey(grp))
                    {
                        sums[grp] += price;
                        counts[grp] += 1;
                    }
                    else
                    {
                        sums[grp] = price;
                        counts[grp] = 1;
                    }
                }
                catch { }
            }

            var avg = new Dictionary<ProductGroup, decimal>();
            foreach (var k in sums.Keys)
                avg[k] = counts[k] > 0 ? sums[k] / counts[k] : 0M;
            return avg;
        }

        public Dictionary<Units, int> GetUnitsDistribution()
        {
            var dist = new Dictionary<Units, int>();
            foreach (DataRow r in WarehouseTable.Rows)
            {
                try
                {
                    var uObj = r["Units"];
                    if (uObj == DBNull.Value) continue;
                    var u = (Units)uObj;
                    if (dist.ContainsKey(u)) dist[u] += 1;
                    else dist[u] = 1;
                }
                catch { }
            }
            return dist;
        }

        public void ExportStatsToCsv<TKey, TValue>(Dictionary<TKey, TValue> stats, string path)
        {
            try
            {
                using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    foreach (var kv in stats)
                    {
                        sw.WriteLine($"{kv.Key},{kv.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to export statistics: " + ex.Message);
            }
        }
    }
}

