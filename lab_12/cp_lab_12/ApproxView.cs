using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cp_lab_12
{
    enum ApproximationMethod
    {
        Polynomial,
        Gaussian,
    }

    partial class ApproxView : UserControl
    {
        private readonly Graph graph;
        private readonly ViewSwitcher switcher;
        private readonly GraphUpdater updater;
        private bool CSVLoaded;
        private double[] LoadedX;
        private double[] LoadedY;

        public ApproxView(Graph g, ViewSwitcher vs, GraphUpdater gu)
        {
            graph = g;
            switcher = vs;
            updater = gu;

            InitializeComponent();
        }

        private void SwitchToPolarButton_Click(object sender, EventArgs e)
        {
            switcher(ViewType.Polar);
        }

        private void SwitchToCartesianButton_Click(object sender, EventArgs e)
        {
            switcher(ViewType.Cartesian);
        }

        private void ApproximateButton_Click(object sender, EventArgs e)
        {
            if (!CSVLoaded)
            {
                return;
            }

            try
            {
                int degree = Convert.ToInt32(ApproxDegree.Value);
                var method = (ApproximationMethod)ApproxTypeSelect.SelectedIndex;

                double[] x, y;
                if (method == ApproximationMethod.Gaussian)
                {
                    (x, y) = (Approximation.HardcodedXdata, Approximation.HardcodedYdata);
                }
                else
                {
                    (x, y) = (LoadedX, LoadedY);
                }

                graph.ClearPlots();

                var dataLS = new LineStyle(Color.Green, 6f, DashStyle.Dot);
                var approxLS = new LineStyle(Color.Blue, 2f, DashStyle.Solid);

                var dataPlt = new Plot(x, y, dataLS);
                graph.AddPlot(dataPlt);

                var (approxX, approxY) = ApproximateData(degree, method);
                var approxPlt = new Plot(approxX, approxY, approxLS);

                graph.AddPlot(approxPlt);

                updater();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating graph: " + ex.Message);
                return;
            }            
        }

        private (double[], double[]) ApproximateData(int degree, ApproximationMethod method)
        {
            var points = Math.Max(50, Math.Min(1000, LoadedX.Length * 10));
            switch (method)
            {
                case ApproximationMethod.Polynomial:
                    var coeffs = Approximation.ApproximatePolynomial(LoadedX, LoadedY, degree);
                    return Approximation.EvaluatePolynomialOnGrid(LoadedX.Min(), LoadedX.Max(), coeffs, degree, points);
                case ApproximationMethod.Gaussian:
                    var gaussParams = Approximation.ApproximateGaussian();
                    return Approximation.EvaluateGaussianOnGrid(gaussParams, points);
                default:
                    throw new NotSupportedException("Unsupported approximation method");
            }
        }

        private void LoadCsvButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() != DialogResult.OK) {
                MessageBox.Show("Dialog failure");
                return;
            }

            try
            {
                var (X, Y) = CsvParser.LoadTwoColumnCsv(dialog.FileName);
                LoadedX = X;
                LoadedY = Y;
                CSVLoaded = true;

                ApproximateButton_Click(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading CSV file: " + ex.Message);
            }
        }

        private void HotReloadEnabler_CheckedChanged(object sender, EventArgs e)
        {
            if (HotReloadEnabler.Checked) 
            {
                ApproxDegree.ValueChanged += ApproximateButton_Click;
                ApproxTypeSelect.SelectedIndexChanged += ApproximateButton_Click;
            } 
            else
            {
                ApproxDegree.ValueChanged -= ApproximateButton_Click;
                ApproxTypeSelect.SelectedIndexChanged -= ApproximateButton_Click;
            }
        }
    }
}
