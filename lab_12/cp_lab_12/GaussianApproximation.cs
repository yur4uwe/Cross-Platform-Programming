using System;
using System.Linq;

namespace cp_lab_12
{
    partial class Approximation
    {
        // NOTE: immutable hardcoded data used for all nonlinear approximations.
        public static readonly double[] HardcodedXdata = {
            8.51602E+01, 8.735245E+01, 8.929174E+01, 9.114671E+01, 9.274874E+01,
            9.401349E+01, 9.544688E+01, 9.578415E+01, 9.738617E+01, 9.806071E+01,
            9.881956E+01, 1.0008432E+02, 1.0160202E+02, 1.039629E+02, 1.0581788E+02,
            1.0834739E+02, 1.118887E+02, 1.1416526E+02, 1.1585160E+02, 1.1661046E+02,
            1.1770658E+02, 1.1956155E+02, 1.2082631E+02, 1.2158516E+02, 1.2352445E+02,
            1.2546374E+02, 1.2698145E+02, 1.2917369E+02, 1.3102867E+02, 1.3229342E+02,
            1.3465430E+02, 1.3591906E+02, 1.3844857E+02, 1.4072513E+02, 1.4401349E+02,
            1.4721754E+02, 1.5286678E+02, 1.5868465E+02, 
            //1.6627319E+02, 1.7841484E+02, 1.8701518E+02, 1.9915683E+02, 2.1576728E+02, 
            //2.3473862E+02, 2.6087690E+02, 2.9519393E+02
        };

        public static readonly double[] HardcodedYdata = {
            2.409070E+00, 3.448280E+00, 5.999060E+00, 9.541800E+00, 1.388758E+01,
            1.761927E+01, 2.281530E+01, 2.678318E+01, 3.278224E+01, 3.684459E+01,
            3.930090E+01, 4.034010E+01, 4.100142E+01, 4.095418E+01, 4.038734E+01,
            4.152102E+01, 4.633916E+01, 5.040151E+01, 5.592820E+01, 6.079358E+01,
            6.447803E+01, 7.482286E+01, 7.789325E+01, 7.987718E+01, 8.134152E+01,
            8.049126E+01, 7.817667E+01, 7.057156E+01, 6.017950E+01, 4.657534E+01,
            3.401039E+01, 2.616911E+01, 1.880019E+01, 1.341521E+01, 8.786020E+00,
            6.188000E+00, 4.251300E+00, 3.070380E+00, 
            //2.786960E+00, 2.172890E+00, 1.700520E+00, 1.794990E+00, 1.747760E+00, 
            //1.653280E+00, 1.417100E+00, 1.322630E+00
        };

        // Model uses Gaussian parameterization compatible with the working implementation:
        // M(x) = A * exp( - b * (x - mu)^2 )
        private static double EvaluateModel(double x, double[] pars, int m)
        {
            double sum = 0.0;
            for (int g = 0; g < m; g++)
            {
                double A = pars[3 * g + 0];
                double b = pars[3 * g + 1];
                double mu = pars[3 * g + 2];

                double bAbs = Math.Abs(b);
                if (bAbs < 1e-16) bAbs = 1e-16;

                double dx = x - mu;
                sum += A * Math.Exp(-bAbs * dx * dx);
            }
            return sum;
        }

        // Compute model values for all x (micro-optimizations: single pass)
        private static double[] ComputeModelValues(double[] x, double[] pars, int m)
        {
            int n = x.Length;
            var vals = new double[n];
            for (int i = 0; i < n; i++) vals[i] = EvaluateModel(x[i], pars, m);
            return vals;
        }

        // Compute residual-function vector F (length = 3*m) used by Newton iterations.
        // Uses same formulas as the original working implementation (diff = ye - model).
        private static double[] ComputeF(double[] x, double[] y, double[] pars, int m, double[] modelVals = null)
        {
            int n = x.Length;
            int pcount = 3 * m;
            var F = new double[pcount];
            if (modelVals == null) modelVals = ComputeModelValues(x, pars, m);

            for (int g = 0; g < m; g++)
            {
                double A = pars[3 * g + 0];
                double b = pars[3 * g + 1];
                double mu = pars[3 * g + 2];

                double sAbs = Math.Abs(b);
                if (sAbs < 1e-16) sAbs = 1e-16;

                double s1 = 0.0, s2 = 0.0, s3 = 0.0;
                for (int i = 0; i < n; i++)
                {
                    double xi = x[i];
                    double yi = y[i];
                    double diff = yi - modelVals[i]; // ye - model
                    double dx = xi - mu;
                    double expTerm = Math.Exp(-sAbs * dx * dx);

                    s1 += diff * expTerm;
                    s2 += diff * (A * (-(dx * dx)) * expTerm);            // d/d b
                    s3 += diff * (A * 2.0 * b * dx * expTerm);            // d/d mu
                }

                F[3 * g + 0] = s1;
                F[3 * g + 1] = s2;
                F[3 * g + 2] = s3;
            }

            return F;
        }

        // Finite-difference Jacobian of F with respect to parameters (central difference).
        private static double[,] ComputeJacobianFD(double[] x, double[] y, double[] pars, int m, double delta = 1e-6)
        {
            int pcount = 3 * m;
            int n = x.Length;
            var J = new double[pcount, pcount];

            for (int col = 0; col < pcount; col++)
            {
                var pPlus = (double[])pars.Clone();
                var pMinus = (double[])pars.Clone();
                pPlus[col] += delta;
                pMinus[col] -= delta;

                var modelPlus = ComputeModelValues(x, pPlus, m);
                var modelMinus = ComputeModelValues(x, pMinus, m);

                var Fplus = ComputeF(x, y, pPlus, m, modelPlus);
                var Fminus = ComputeF(x, y, pMinus, m, modelMinus);

                for (int row = 0; row < pcount; row++)
                    J[row, col] = (Fplus[row] - Fminus[row]) / (2.0 * delta);
            }

            return J;
        }

        private static double Norm(double[] v)
        {
            double s = 0.0;
            for (int i = 0; i < v.Length; i++) s += v[i] * v[i];
            return Math.Sqrt(s);
        }

        // Cleaned, lean inlined decomposition algorithm ported from the working implementation.
        public static double[] ApproximateGaussian()
        {
            double[] x = HardcodedXdata;
            double[] y = HardcodedYdata;

            // initial guess from working implementation
            double[] k = new double[6] {
                79.0, 0.005, 127.0,   // A1, b1, mu1
                38.0, 0.004, 103.0    // A2, b2, mu2
            };

            const double Eps = 1e-8;
            const int MaxIterations = 2000;
            const double Damping = 0.3;
            const double Delta = 1e-6;
            const int m = 2;
            int pcount = 3 * m;

            for (int iter = 0; iter < MaxIterations; iter++)
            {
                var modelVals = ComputeModelValues(x, k, m);
                var F = ComputeF(x, y, k, m, modelVals);

                double normF = Norm(F);
                if (normF < Eps) return k;

                var J = ComputeJacobianFD(x, y, k, m, Delta);

                // Solve J * dk = -F
                var negF = new double[pcount];
                for (int i = 0; i < pcount; i++) negF[i] = -F[i];

                double[] dk;
                try
                {
                    dk = Gauss(J, negF);
                }
                catch
                {
                    // fallback tiny gradient step when Jacobian solve fails
                    double small = 1e-3;
                    dk = new double[pcount];
                    for (int i = 0; i < pcount; i++) dk[i] = small * negF[i];
                }

                double normDk = Norm(dk);
                if (normDk < Eps) return k;

                // damped update
                for (int i = 0; i < pcount; i++) k[i] += Damping * dk[i];

                // enforce physical constraints: amplitude and width positive
                for (int g = 0; g < m; g++)
                {
                    if (k[3 * g + 0] < 0) k[3 * g + 0] = Math.Abs(k[3 * g + 0]);
                    if (k[3 * g + 1] < 0) k[3 * g + 1] = Math.Abs(k[3 * g + 1]);
                    if (Math.Abs(k[3 * g + 1]) < 1e-16) k[3 * g + 1] = 1e-16;
                }
            }

            // return last estimate if not converged
            return k;
        }

        public static (double[], double[]) EvaluateGaussianOnGrid(double[] parameters, int gridPoints)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (gridPoints <= 0) throw new ArgumentOutOfRangeException(nameof(gridPoints));

            double xmin = HardcodedXdata.Min();
            double xmax = HardcodedXdata.Max();
            double step = (xmax - xmin) / (gridPoints - 1);

            var xg = new double[gridPoints];
            var yg = new double[gridPoints];

            for (int i = 0; i < gridPoints; i++)
            {
                double xv = xmin + i * step;
                xg[i] = xv;
                yg[i] = EvaluateModel(xv, parameters, 2);
            }

            return (xg, yg);
        }
    }
}