using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Globalization;

namespace cp_lab_12
{
    public partial class Form1 : Form
    {
        private readonly Graph graph = new Graph();

        // Holds CSV data when loaded
        private double[] loadedX;
        private double[] loadedY;
        private bool csvLoaded;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Paint += PictureBox1_Paint;

            var functions = Enum.GetValues(typeof(CartesianFunction)).Cast<CartesianFunction>().ToList();
            FuncComboBox.DataSource = functions;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            graph.Draw(e.Graphics, pictureBox1.ClientRectangle);
        }

        private double[] LinSpace(double start, double end, int num)
        {
            double[] result = new double[num];
            double step = (end - start) / (num - 1);
            for (int i = 0; i < num; i++)
            {
                result[i] = start + step * i;
            }
            return result;
        }

        private double[] ComputeFunctionValues(double[] x, Func<double, double> f)
        {
            double[] y = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                y[i] = f(x[i]);
            }
            return y;
        }

        // Centralized plot update routine — used by button, hot-reload and CSV loader
        private void UpdateGraph(object sender, EventArgs e)
        {
            try
            {
                graph.ClearPlots();

                if (csvLoaded)
                {
                    // plot loaded CSV (markers and optional approximation)
                    var csvStyle = new LineStyle(Color.Green, 8f, DashStyle.Dot);
                    var csvPlot = new Plot(loadedX, loadedY, csvStyle);
                    graph.AddPlot(csvPlot);

                    if (ToApproximateCheckBox.Checked)
                    {
                        if (!int.TryParse(ApproxDegree.Text, out int deg))
                            throw new FormatException("Invalid approximation degree.");

                        var coeffs = Approximation.ApproximatePolynomial(loadedX, loadedY, deg) ?? throw new InvalidOperationException("Approximation failed (singular system).");
                        var (xGrid, yGrid) = Approximation.EvaluatePolynomialOnGrid(loadedX.Min(), loadedX.Max(), coeffs, deg, Math.Max(100, loadedX.Length * 10));

                        var approxStyle = new LineStyle(Color.Red, 2f, DashStyle.Solid);
                        graph.AddPlot(new Plot(xGrid, yGrid, approxStyle));
                    }
                }
                else
                {
                    // generate from UI-selected function
                    double a = Convert.ToDouble(RangeStart.Value);
                    double b = Convert.ToDouble(RangeEnd.Value);
                    int N = Convert.ToInt32(PointCount.Value);
                    int degree = Convert.ToInt32(ApproxDegree.Value);
                    var selectedf = (CartesianFunction)FuncComboBox.SelectedItem;
                    double offset = Convert.ToDouble(ShiftNumeric.Value);
                    double multiplier = Convert.ToDouble(MultiplierNumeric.Value);

                    double[] x = LinSpace(a, b, N);
                    double[] y = ComputeFunctionValues(x, FunctionCatalog.GetCartesian(selectedf, multiplier, offset));

                    var rawStyle = new LineStyle(Color.Blue, 2f, DashStyle.Solid);
                    var rawPlot = new Plot(x, y, rawStyle);
                    graph.AddPlot(rawPlot);

                    if (ToApproximateCheckBox.Checked)
                    {
                        double[] coeffs = Approximation.ApproximatePolynomial(x, y, degree);
                        if (coeffs == null)
                            throw new InvalidOperationException("Approximation failed (singular system).");

                        int gridPoints = Math.Max(50, Math.Min(1000, N * 10));
                        var (xGrid, yGrid) = Approximation.EvaluatePolynomialOnGrid(a, b, coeffs, degree, gridPoints);

                        var approxStyle = new LineStyle(Color.Red, 2f, DashStyle.Solid);
                        var approxPlot = new Plot(xGrid, yGrid, approxStyle);
                        graph.AddPlot(approxPlot);
                    }
                }

                pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating graph: " + ex.Message);
            }
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            UpdateGraph(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                RangeStart.ValueChanged += UpdateGraph;
                RangeEnd.ValueChanged += UpdateGraph;
                PointCount.ValueChanged += UpdateGraph;
                ApproxDegree.ValueChanged += UpdateGraph;
                FuncComboBox.SelectedIndexChanged += UpdateGraph;
                ShiftNumeric.ValueChanged += UpdateGraph;
                MultiplierNumeric.ValueChanged += UpdateGraph;
            }
            else
            {
                RangeStart.ValueChanged -= UpdateGraph;
                RangeEnd.ValueChanged -= UpdateGraph;
                PointCount.ValueChanged -= UpdateGraph;
                ApproxDegree.ValueChanged -= UpdateGraph;
                FuncComboBox.SelectedIndexChanged -= UpdateGraph;
                ShiftNumeric.ValueChanged -= UpdateGraph;
                MultiplierNumeric.ValueChanged -= UpdateGraph;
            }
        }

        private void SwitchToPolarButton_Click(object sender, EventArgs e)
        {
            var f2 = new Form2
            {
                StartPosition = FormStartPosition.CenterScreen,
                Owner = this
            };
            f2.FormClosed += (s, _) =>
            {
                this.Show();
                f2.Dispose();
            };

            this.Hide();
            f2.Show();
        }

        private void LoadCsvButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var (X, Y) = CsvParser.LoadTwoColumnCsv(dialog.FileName);
                        loadedX = X;
                        loadedY = Y;
                        csvLoaded = true;

                        FuncComboBox.Enabled = false;
                        RangeStart.Enabled = false;
                        RangeEnd.Enabled = false;
                        PointCount.Enabled = false;
                        ShiftNumeric.Enabled = false;
                        MultiplierNumeric.Enabled = false;

                        UpdateGraph(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading CSV file: " + ex.Message);
                    }
                }
            }
        }
    }
}
