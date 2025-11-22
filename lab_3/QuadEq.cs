using System;

class QuadEq
{
    static void Main()
    {
        double a = 2, b = -5, c = 3, root1, root2; // Example coefficients for the equation x^2 - 3x + 2 = 0

        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Two real roots: {root1} and {root2}");
        }
        else if (discriminant == 0)
        {
            double root = -b / (2 * a);
            Console.WriteLine($"One real root: {root}");
        }
        else
        {
            Console.WriteLine("No real roots.");
        }
    }
}