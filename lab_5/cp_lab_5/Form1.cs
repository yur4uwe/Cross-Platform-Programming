using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cp_lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void solve_Click(object sender, EventArgs e)
        {
            Method method;
            if (BisectionRadio.Checked)
                method = Method.Bisection;
            else if (NewtonRadio.Checked)
                method = Method.Newton;
            else
            {
                MessageBox.Show("Select a method");
                return;
            }

            double a = 0, b = 1, eps = 1e-6;
            int kmax = 100;

            try
            {
                a = double.Parse(ABox.Text);
            }
            catch
            {
                ABox.Text = "0";
                a = 0;
            }

            try
            {
                b = double.Parse(BBox.Text);
            }
            catch
            {
                BBox.Text = "1";
                b = 1;
            }

            try
            {
                eps = double.Parse(EpsBox.Text);
            }
            catch
            {
                EpsBox.Text = "1e-6";
                eps = 1e-6;
            }

            if (method == Method.Newton)
            {
                try
                {
                    kmax = int.Parse(KmaxBox.Text);
                }
                catch
                {
                    KmaxBox.Text = "100";
                    kmax = 100;
                }
            }

            if (a >= b) (a, b) = (b, a);

            if (eps <= 0)
            {
                MessageBox.Show("Epsilon must be positive");
                return;
            }

            if (method == Method.Newton && kmax <= 0)
            {
                MessageBox.Show("Max iterations must be positive");
                return;
            }

            RootFinder rf = new RootFinder(eps, kmax, msg => RootBox.Text = msg, msg => MessageBox.Show(msg), msg => IterBox.Text = msg);

            if (F1Radio.Checked)
                rf.ChangeFunction(x => x * x - 4);
            else if (F2Radio.Checked)
                rf.ChangeFunction(x => 3 * x - 4 * Math.Log(x) - 5);
            else if (F3Radio.Checked)
                rf.ChangeFunction(x => Math.Exp(x) - 3 * x);
            else
            {
                MessageBox.Show("Select an equation");
                return;
            }

            rf.FindRoot(a, b, method);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox box)
                {
                    box.Clear();
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
