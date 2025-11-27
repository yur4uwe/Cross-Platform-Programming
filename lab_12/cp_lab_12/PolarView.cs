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
    partial class PolarView : UserControl
    {
        private readonly Graph graph;
        private readonly ViewSwitcher switcher;
        private readonly GraphUpdater updater;

        public PolarView(Graph g, ViewSwitcher vs, GraphUpdater gu)
        {
            graph = g;
            switcher = vs;
            updater = gu;

            InitializeComponent();

            var funcs = Enum.GetValues(typeof(PolarFunction)).Cast<PolarFunction>().ToList();
            FuncComboBox.DataSource = funcs;
        }

        private double[] RadSpace(double start, double end, int num)
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

        private (double[], double[]) ToCartesian(double[] r, double[] theta)
        {
            if (r.Length != theta.Length)
                throw new ArgumentException("Input arrays must have the same length.");
            double[] x = new double[r.Length];
            double[] y = new double[r.Length];
            for (int i = 0; i < r.Length; i++)
            {
                x[i] = r[i] * Math.Cos(theta[i]);
                y[i] = r[i] * Math.Sin(theta[i]);
            }
            return (x, y);
        }

        private void SwitchToApprox_Click(object sender, EventArgs e)
        {
            switcher(ViewType.Approximation);
        }

        private void SwitchtoCartesianButton_Click(object sender, EventArgs e)
        {
            switcher(ViewType.Cartesian);
        }

        private void HotReload_CheckedChanged(object sender, EventArgs e)
        {
            if (HotReload.Checked)
            {
                Points.ValueChanged += GraphButton_Click;
                PeriodNum.ValueChanged += GraphButton_Click;
                FuncComboBox.SelectedIndexChanged += GraphButton_Click;
                ParamANumeric.ValueChanged += GraphButton_Click;
                ParamBNumeric.ValueChanged += GraphButton_Click;
            }
            else
            {
                Points.ValueChanged -= GraphButton_Click;
                PeriodNum.ValueChanged -= GraphButton_Click;
                FuncComboBox.SelectedIndexChanged -= GraphButton_Click;
                ParamANumeric.ValueChanged -= GraphButton_Click;
                ParamBNumeric.ValueChanged -= GraphButton_Click;
            }
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            try 
            {
                int pointsCount = Convert.ToInt32(Points.Value);
                int periods = Convert.ToInt32(PeriodNum.Value);
                PolarFunction selectedFunction = (PolarFunction)FuncComboBox.SelectedItem;
                double a = Convert.ToDouble(ParamANumeric.Value);
                double b = Convert.ToDouble(ParamBNumeric.Value);

                var F = FunctionCatalog.GetPolarRadius(selectedFunction, a, b);
                double[] theta = RadSpace(0, 2 * Math.PI * periods, pointsCount);
                double[] r = ComputeFunctionValues(theta, F);

                var (x, y) = ToCartesian(r, theta);

                var polarLS = new LineStyle(Color.Blue, 2.0f, DashStyle.Solid);

                var PolarPlot = new Plot(x, y, polarLS);

                graph.ClearPlots();
                graph.AddPlot(PolarPlot);

                updater();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating graph: " + ex.Message);
            }
        }
    }
}
