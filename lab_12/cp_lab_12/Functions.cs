using System;

namespace cp_lab_12
{
    // Enum holds only names/ids.
    public enum CartesianFunction
    {
        Sine,
        Cosine,
        Parabola,
        Cubic,
        Gaussian
    }

    public enum  PolarFunction 
    {
        ArchimedeanSpiral,
        LogarithmicSpiral,
        Rose,
        Cardioid
    }

    // Small catalog that returns delegates (closures) and labels.
    public static class FunctionCatalog
    {
        // Returns a cartesian function y = f(x). Parameters (a,b) are interpreted per function.
        // Throws ArgumentException if id is a polar function.
        public static Func<double, double> GetCartesian(CartesianFunction id, double a = 1.0, double b = 0.0)
        {
            switch (id)
            {
                case CartesianFunction.Sine: return x => Math.Sin(a * x + b);            // a = frequency, b = phase
                case CartesianFunction.Cosine: return x => Math.Cos(a * x + b);            // a = frequency, b = phase
                case CartesianFunction.Parabola: return x => a * x * x + b;                  // a = scale, b = vertical shift
                case CartesianFunction.Cubic: return x => a * x * x * x + b;              // a = scale, b = shift
                case CartesianFunction.Gaussian: return x => a * Math.Exp(-Math.Pow((x - b), 2)); // a = amplitude, b = center
                default:
                    throw new ArgumentException("Requested function is not cartesian", nameof(id));
            }
        }

        // Returns a polar radius r = f(theta). Parameters (a,b) are interpreted per function.
        // Throws ArgumentException if id is a cartesian function.
        public static Func<double, double> GetPolarRadius(PolarFunction id, double a = 1.0, double b = 1.0)
        {
            switch (id)
            {
                case PolarFunction.ArchimedeanSpiral: return theta => a * theta;
                case PolarFunction.LogarithmicSpiral: return theta => a * Math.Exp(1/b * theta);
                case PolarFunction.Rose: return theta => a * Math.Cos(b * theta);
                case PolarFunction.Cardioid: return theta => a * (1 + Math.Cos(theta));
                default:
                    throw new ArgumentException("Requested function is not polar", nameof(id));
            }
        }
    }
}