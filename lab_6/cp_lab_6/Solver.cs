using System;

namespace cp_lab_6
{
    internal class Solver
    {
        public double[] LUDecomposition(double[,] A, double[] b, out double[,] C)
        {
            if (A == null) throw new ArgumentNullException(nameof(A));
            if (b == null) throw new ArgumentNullException(nameof(b));

            int n = A.GetLength(0);
            if (A.GetLength(1) != n) throw new ArgumentException("Matrix A must be square.", nameof(A));
            if (b.Length != n) throw new ArgumentException("Vector b length must match matrix dimension.", nameof(b));

            double[,] L = new double[n, n];
            double[,] U = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    double sum = 0.0;
                    for (int k = 0; k < i; k++)
                        sum += L[i, k] * U[k, j];

                    U[i, j] = A[i, j] - sum;
                }

                if (Math.Abs(U[i, i]) < 1e-12)
                    throw new InvalidOperationException($"Zero (or nearly zero) pivot encountered at U[{i},{i}]. Matrix may be singular or require pivoting.");

                L[i, i] = 1.0;
                for (int j = i + 1; j < n; j++)
                {
                    double sum = 0.0;
                    for (int k = 0; k < i; k++)
                        sum += L[j, k] * U[k, i];

                    L[j, i] = (A[j, i] - sum) / U[i, i];
                }
            }

            C = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j >= i) C[i, j] = U[i, j];
                    else C[i, j] = L[i, j];
                }
            }

            double[] y = new double[n];
            for (int i = 0; i < n; i++)
            {
                double sum = 0.0;
                for (int k = 0; k < i; k++)
                    sum += L[i, k] * y[k];
                y[i] = b[i] - sum;
            }

            double[] x = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0.0;
                for (int k = i + 1; k < n; k++)
                    sum += U[i, k] * x[k];

                x[i] = (y[i] - sum) / U[i, i];
            }

            return x;
        }

        public double[] Gauss(double[,] A, double[] b, out double[,] C)
        {
            if (A == null) throw new ArgumentNullException(nameof(A));
            if (b == null) throw new ArgumentNullException(nameof(b));
            int n = A.GetLength(0);
            if (A.GetLength(1) != n) throw new ArgumentException("Matrix A must be square.", nameof(A));
            if (b.Length != n) throw new ArgumentException("Vector b length must match matrix dimension.", nameof(b));

            double[,] Ab = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Ab[i, j] = A[i, j];
                }
                Ab[i, n] = b[i];
            }

            for (int i = 0; i < n; i++)
            {
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(Ab[k, i]) > Math.Abs(Ab[maxRow, i]))
                    {
                        maxRow = k;
                    }
                }
                if (maxRow != i)
                {
                    for (int j = i; j <= n; j++)
                    {
                        double temp = Ab[i, j];
                        Ab[i, j] = Ab[maxRow, j];
                        Ab[maxRow, j] = temp;
                    }
                }
                if (Math.Abs(Ab[i, i]) < 1e-12)
                    throw new InvalidOperationException($"Zero (or nearly zero) pivot encountered at row {i}. Matrix may be singular or require pivoting.");
                for (int k = i + 1; k < n; k++)
                {
                    double factor = Ab[k, i] / Ab[i, i];
                    for (int j = i; j <= n; j++)
                    {
                        Ab[k, j] -= factor * Ab[i, j];
                    }
                }
            }

            C = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C[i, j] = Ab[i, j];
                }
            }

            double[] x = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0.0;
                for (int j = i + 1; j < n; j++)
                {
                    sum += Ab[i, j] * x[j];
                }
                if (Math.Abs(Ab[i, i]) < 1e-12)
                    throw new InvalidOperationException($"Zero (or nearly zero) pivot encountered at back-substitution row {i}.");
                x[i] = (Ab[i, n] - sum) / Ab[i, i];
            }

            return x;
        }
    }

}
