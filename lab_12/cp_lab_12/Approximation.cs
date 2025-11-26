using System;

namespace cp_lab_12
{
    internal class Approximation
    {
        // Sum elements of an array
        private static double Sum(double[] arr)
        {
            double s = 0.0;
            foreach (var v in arr)
            {
                s += v;
            }
            return s;
        }

        // Gaussian elimination with partial pivoting.
        // A: square matrix (will not be modified - we operate on a copy).
        // B: right-hand side vector.
        // n: matrix dimension.
        // X: out solution vector (assigned when returns true).
        public static double[] Gauss(double[,] A, double[] B, int n)
        {
            if (A == null) throw new ArgumentNullException(nameof(A));
            if (B == null) throw new ArgumentNullException(nameof(B));
            if (n <= 0) throw new ArgumentOutOfRangeException(nameof(n));
            if (B.Length < n) throw new ArgumentException("B length is less than n.");

            // Make local copies to avoid mutating the caller's arrays
            double[,] a = new double[n, n];
            double[] b = new double[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = B[i];
                for (int j = 0; j < n; j++)
                    a[i, j] = A[i, j];
            }

            const double eps = 1e-12;

            // Forward elimination with partial pivoting
            for (int col = 0; col < n; col++)
            {
                // Find pivot
                int pivotRow = col;
                double maxAbs = Math.Abs(a[col, col]);
                for (int r = col + 1; r < n; r++)
                {
                    double val = Math.Abs(a[r, col]);
                    if (val > maxAbs)
                    {
                        maxAbs = val;
                        pivotRow = r;
                    }
                }

                if (maxAbs < eps)
                {
                    // Matrix is singular (or nearly singular)
                    return null;
                }

                // Swap rows if needed
                if (pivotRow != col)
                {
                    for (int c = col; c < n; c++)
                    {
                        double tmp = a[col, c];
                        a[col, c] = a[pivotRow, c];
                        a[pivotRow, c] = tmp;
                    }
                    double tmpb = b[col];
                    b[col] = b[pivotRow];
                    b[pivotRow] = tmpb;
                }

                // Eliminate lower rows
                for (int r = col + 1; r < n; r++)
                {
                    double factor = a[r, col] / a[col, col];
                    // Update row r
                    for (int c = col; c < n; c++)
                    {
                        a[r, c] -= factor * a[col, c];
                    }
                    b[r] -= factor * b[col];
                }
            }

            // Back substitution
            double[] x = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = b[i];
                for (int j = i + 1; j < n; j++)
                {
                    sum -= a[i, j] * x[j];
                }

                if (Math.Abs(a[i, i]) < eps)
                    return null; // singular

                x[i] = sum / a[i, i];
            }

            return x;
        }

        // Build and solve normal equations for polynomial least squares of degree 'degree'.
        // xData, yData: input data (same length).
        // coeffs (ref): a length-(degree+1) array; on success filled with polynomial coefficients [c0, c1, ..., c_degree].
        // Returns true on success, false on failure (e.g., singular normal matrix).
        public static double[] ApproximatePolynomial(double[] xData, double[] yData, int degree)
        {
            if (xData == null) throw new ArgumentNullException(nameof(xData));
            if (yData == null) throw new ArgumentNullException(nameof(yData));
            if (degree < 0) throw new ArgumentOutOfRangeException(nameof(degree));

            int m = degree;
            int dim = m + 1;

            // Precompute sums S[k] = sum x_i^k for k = 0..2m
            double[] sumsX = new double[2 * m + 1];
            for (int k = 0; k < sumsX.Length; k++)
            {
                double s = 0.0;
                for (int i = 0; i < xData.Length; i++)
                {
                    s += Math.Pow(xData[i], k);
                }
                sumsX[k] = s;
            }

            // Compute right-hand side T[k] = sum y_i * x_i^k for k = 0..m
            double[] rhs = new double[dim];
            for (int k = 0; k < dim; k++)
            {
                double t = 0.0;
                for (int i = 0; i < xData.Length; i++)
                {
                    t += yData[i] * Math.Pow(xData[i], k);
                }
                rhs[k] = t;
            }

            // Build normal matrix A[i,j] = S[i+j]
            double[,] normalA = new double[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    normalA[i, j] = sumsX[i + j];
                }
            }

            // Solve A * coeffs = rhs
            return Gauss(normalA, rhs, dim);
        }

        // Evaluate polynomial (coefficients c0..cm) on a uniform grid between xStart and xEnd.
        // coeffs: coefficients length m+1
        // gridPoints: number of samples (ngr in original)
        // xGrid, yGrid: ref arrays to be filled (length must be at least gridPoints)
        public static (double[], double[]) EvaluatePolynomialOnGrid(double xStart, double xEnd, double[] coeffs, int degree, int gridPoints)
        {
            if (coeffs == null) throw new ArgumentNullException(nameof(coeffs));
            if (degree < 0) throw new ArgumentOutOfRangeException(nameof(degree));
            if (gridPoints <= 0) throw new ArgumentOutOfRangeException(nameof(gridPoints));

            double step = (xEnd - xStart) / (gridPoints - 1);
            double x = xStart;

            double[] xGrid = new double[gridPoints];
            double[] yGrid = new double[gridPoints];

            for (int i = 0; i < gridPoints; i++)
            {
                // Horner evaluation
                double value = coeffs[degree];
                for (int j = degree - 1; j >= 0; j--)
                    value = value * x + coeffs[j];

                xGrid[i] = x;
                yGrid[i] = value;
                x += step;
            }

            return (xGrid, yGrid);
        }
    }
}
