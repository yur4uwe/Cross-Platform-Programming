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
    public partial class Form2 : Form
    {
        private readonly Graph graph = new Graph();

        public Form2()
        {
            InitializeComponent();

            GraphBox.Paint += GraphBox_Paint;

            var functions = Enum.GetValues(typeof(PolarFunction)).Cast<PolarFunction>().ToList();
            FuncComboBox.DataSource = functions;
        }

        private void GraphBox_Paint(object sender, PaintEventArgs e)
        {
            graph.Draw(e.Graphics, GraphBox.ClientRectangle);
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

        private (double[], double[]) ToCartesian(double [] r, double[] theta)
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

        private void GraphButton_Click(object sender, EventArgs e)
        {
            double numOfPeriods, a, b;
            int N;
            PolarFunction selectedf;
            try 
            {
                numOfPeriods = Convert.ToDouble(PeriodNum.Value);
                N = int.Parse(Points.Text);
                selectedf = (PolarFunction)FuncComboBox.SelectedItem;
                a = Convert.ToDouble(ParamANumeric.Value);
                b = Convert.ToDouble(ParamBNumeric.Value);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please enter numeric values.");
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Input value is too large or too small.");
                return;
            }

            var F = FunctionCatalog.GetPolarRadius(selectedf, a, b);
            double[] theta = RadSpace(0, 2 * Math.PI * numOfPeriods, N);
            double[] r = ComputeFunctionValues(theta, F);

            var (x, y) = ToCartesian(r, theta);

            var ASLS = new LineStyle(Color.Blue, 2.0f, DashStyle.Solid);

            var ArchSpiralPlot = new Plot(x, y, ASLS);

            graph.ClearPlots();
            graph.AddPlot(ArchSpiralPlot);

            GraphBox.Invalidate();
        }

        private void HotReload_CheckedChanged(object sender, EventArgs e)
        {
            if (HotReload.Checked)
            {
                PeriodNum.ValueChanged += GraphButton_Click;
                ParamANumeric.ValueChanged += GraphButton_Click;
                ParamBNumeric.ValueChanged += GraphButton_Click;
                FuncComboBox.SelectedIndexChanged += GraphButton_Click;
                Points.ValueChanged += GraphButton_Click;
                GraphBox.Paint += GraphButton_Click;
            }
            else
            {
                PeriodNum.ValueChanged -= GraphButton_Click;
                ParamANumeric.ValueChanged -= GraphButton_Click;
                ParamBNumeric.ValueChanged -= GraphButton_Click;
                FuncComboBox.SelectedIndexChanged -= GraphButton_Click;
                Points.ValueChanged -= GraphButton_Click;
                GraphBox.Paint -= GraphButton_Click;
            }
        }

        private void SwitchtoCartesianButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    } 
}
