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
    partial class CartesianView : UserControl
    {
        private readonly Graph graph;
        private readonly ViewSwitcher switcher;
        private readonly GraphUpdater updater;

        public CartesianView(Graph g, ViewSwitcher vs, GraphUpdater gu)
        {
            graph = g;
            switcher = vs;
            updater = gu;

            InitializeComponent();

            var funcs = Enum.GetValues(typeof(CartesianFunction)).Cast<CartesianFunction>().ToArray();
            FuncComboBox.DataSource = funcs;
        }

        private double[] LinearSpace(double a, double b, int n)
        {
            var res = new double[n];
            var step = (b - a) / n;

            for (int i = 0; i < n; i++)
            {
                res[i] = (double)(a + step * i);
            }

            return res;
        }

        private double[] Map(double[] x, Func<double, double> func)
        {
            var res = new double[x.Length];

            for (int i = 0; i<x.Length; i++)
            {
                res[i] = func(x[i]);
            }

            return res;
        }

        private void SwitchToApproxButton_Click(object sender, EventArgs e)
        {
            switcher(ViewType.Approximation);
        }

        private void SwitchToPolarButton_Click(object sender, EventArgs e)
        {
            switcher(ViewType.Polar);
        }

        private void HotReload_CheckedChanged(object sender, EventArgs e)
        {
            if (HotReload.Checked)
            {
                RangeStart.ValueChanged += GraphButton_Click;
                RangeEnd.ValueChanged += GraphButton_Click;
                PointCount.ValueChanged += GraphButton_Click;
                FuncComboBox.SelectedIndexChanged += GraphButton_Click;
                MultiplierNumeric.ValueChanged += GraphButton_Click;
                ShiftNumeric.ValueChanged += GraphButton_Click;
            }
            else
            {
                RangeStart.ValueChanged -= GraphButton_Click;
                RangeEnd.ValueChanged -= GraphButton_Click;
                PointCount.ValueChanged -= GraphButton_Click;
                FuncComboBox.SelectedValueChanged -= GraphButton_Click;
                MultiplierNumeric.ValueChanged -= GraphButton_Click;
                ShiftNumeric.ValueChanged -= GraphButton_Click;
            }
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            try
            {
                double a = (double)RangeStart.Value;
                double b = (double)RangeEnd.Value;
                int N = (int)PointCount.Value;
                CartesianFunction func = (CartesianFunction)FuncComboBox.SelectedIndex;
                double mult = (double)MultiplierNumeric.Value;
                double shift = (double)ShiftNumeric.Value;

                var dataX = LinearSpace(a, b, N);
                var dataY = Map(dataX, FunctionCatalog.GetCartesian(func, mult, shift));

                var dataLS = new LineStyle(Color.Blue, 2f, DashStyle.Solid);

                var dataPlot = new Plot(dataX, dataY, dataLS);

                graph.ClearPlots();
                graph.AddPlot(dataPlot);

                updater();
            } 
            catch 
            {
                MessageBox.Show("Error in rendering"); 
                return;
            }
        }
    }
}
