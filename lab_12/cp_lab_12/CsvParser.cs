using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace cp_lab_12
{
    /// <summary>
    /// Small CSV loader for two-column numeric CSV files.
    /// - Auto-detects delimiter (comma / semicolon / tab) on first non-empty line.
    /// - Skips a header row when the first non-empty row is non-numeric.
    /// - Throws on malformed lines (wrong columns or non-numeric values).
    /// </summary>
    public static class CsvParser
    {
        private static bool TryParseDoubleFlexible(string s, out double value)
        {
            s = (s ?? string.Empty).Trim();
            if (s.Length >= 2 && s[0] == '"' && s[s.Length - 1] == '"')
                s = s.Substring(1, s.Length - 2).Trim();

            if (double.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out value)) return true;
            if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out value)) return true;
            return double.TryParse(s, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out value);
        }

        public static (double[] X, double[] Y) LoadTwoColumnCsv(string path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
                throw new FileNotFoundException("CSV file not found.", path);

            var xs = new List<double>();
            var ys = new List<double>();

            using (var reader = new StreamReader(path))
            {
                string line;
                int lineNumber = 0;
                bool headerSkipped = false;
                char delimiter = ',';
                bool delimiterDetected = false;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    if (!delimiterDetected)
                    {
                        int commaCount = line.Count(c => c == ',');
                        int semicolonCount = line.Count(c => c == ';');
                        int tabCount = line.Count(c => c == '\t');

                        if (commaCount >= semicolonCount && commaCount >= tabCount && commaCount > 0) delimiter = ',';
                        else if (semicolonCount >= commaCount && semicolonCount >= tabCount && semicolonCount > 0) delimiter = ';';
                        else if (tabCount > 0) delimiter = '\t';
                        else delimiter = ','; // fallback

                        delimiterDetected = true;
                    }

                    var parts = line.Split(new[] { delimiter }, StringSplitOptions.None);
                    if (parts.Length < 2)
                        throw new FormatException($"Malformed CSV at line {lineNumber}: expected at least 2 columns using delimiter '{delimiter}'.");

                    string s0 = parts[0].Trim().Trim('"');
                    string s1 = parts[1].Trim().Trim('"');

                    double v0, v1;
                    bool looksNumeric = TryParseDoubleFlexible(s0, out v0) && TryParseDoubleFlexible(s1, out v1);

                    if (!headerSkipped)
                    {
                        if (!looksNumeric)
                        {
                            // first non-empty non-numeric row — treat as header and skip
                            headerSkipped = true;
                            continue;
                        }
                        headerSkipped = true;
                    }

                    if (!TryParseDoubleFlexible(s0, out v0) || !TryParseDoubleFlexible(s1, out v1))
                        throw new FormatException($"Malformed numeric value at line {lineNumber}.");

                    xs.Add(v0);
                    ys.Add(v1);
                }
            }

            if (xs.Count == 0)
                throw new FormatException("CSV contains no numeric data.");

            return (xs.ToArray(), ys.ToArray());
        }
    }
}
