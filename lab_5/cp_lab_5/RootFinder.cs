using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_5
{
    enum Method
    {
        Bisection,
        Newton,
    }

    internal class RootFinder
    {
        private Func<double, double> f;
        private double eps;
        private int kmax;
        private readonly double h = 1e-6;
        private readonly Action<string> resultLog = Console.WriteLine;
        private readonly Action<string> errorLog = Console.WriteLine;
        private readonly Action<string> iterationLog = Console.WriteLine;

        public RootFinder(double eps, int kmax, Action<string> resultLog, Action<string> errorLog, Action<string> iterationLog)
        {
            this.eps = eps;
            this.kmax = kmax;
            this.resultLog = resultLog;
            this.errorLog = errorLog;
            this.iterationLog = iterationLog;
        }

        public void ChangeFunction(Func<double, double> f)
        {
            this.f = f;
        }

        private double df(double x)
        {
            return (f(x + h) - f(x - h)) / (2 * h);
        }

        private double d2f(double x)
        {
            return (f(x + h) - 2 * f(x) + f(x - h)) / (h * h);
        }

        public void FindRoot(double a, double b, Method m)
        {
            switch (m)
            {
                case Method.Bisection:
                    Bisection(a, b);
                    break;
                case Method.Newton:
                    Newton(a, b);
                    break;
                default:
                    errorLog("Unknown method");
                    break;
            }
        }

        private bool WriteRes(double x, int count)
        {
            int precision = -(int)Math.Log10(eps);

            if (Math.Abs(f(x)) < eps)
            {
                resultLog(x.ToString("F" + precision));
                iterationLog(count.ToString());
                return true;
            }
            return false;
        }

        private void Bisection(double l, double r)
        {
            if (l > r) (l, r) = (r, l);

            int count = 0;

            if (f(l) * f(r) > 0)
            {
                resultLog("No solution to be found here");
                return;
            }

            if (WriteRes(l, count) || WriteRes(r, count)) return;

            while (Math.Abs(l - r) > eps)
            {
                count++;
                double mid = 0.5 * (l + r);

                if (WriteRes(mid, count)) return;

                if (f(l) * f(mid) < 0) r = mid;
                else l = mid;
            }

            WriteRes(0.5 * (l + r), count);
        }

        private void Newton(double a, double b)
        {
            if (a > b) (a, b) = (b, a);

            double x = b;

            if (f(b) * d2f(b) < 0)
            {
                x = a;
                if (f(a) * d2f(a) < 0)
                {
                    errorLog("Convergence isn't guaranteed");
                }
            }

            for (int i = 0; i < kmax; i++)
            {
                if (Math.Abs(x) > 1e6) errorLog("Divergence detected");

                double dx = df(x);
                if (Math.Abs(dx) < 1e-12)
                    errorLog($"Zero derivative exception at x={x}");

                double diff = f(x) / dx;
                x -= diff;

                if (WriteRes(x, i)) return;
            }

            resultLog("No solution found");
        }
    }
}
