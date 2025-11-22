using System;

class Newton
{
    private static readonly double EPS = 1E-10;

    static double F(double x)
    {
        return x * x - 2; 
    }

    static double FPrime(double x)
    {
        return 2 * x;
    }

    static void Main()
    {
        double x0 = 1.0;
        double x1;

        while (true)
        {
            x1 = x0 - F(x0) / FPrime(x0);
            if (Math.Abs(x1 - x0) < EPS)
                break;
            x0 = x1;
        }

        Console.WriteLine($"Root: {x1}");
    }
}