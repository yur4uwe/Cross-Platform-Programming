using System;

namespace cp_lab_12
{
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

    public static class FunctionCatalog
    {
        public static Func<double, double> GetCartesian(CartesianFunction id, double a = 1.0, double b = 0.0)
        {
            switch (id)
            {
                case CartesianFunction.Sine: return x => Math.Sin(a * x + b);
                case CartesianFunction.Cosine: return x => Math.Cos(a * x + b);
                case CartesianFunction.Parabola: return x => a * x * x + b;
                case CartesianFunction.Cubic: return x => a * x * x * x + b;
                case CartesianFunction.Gaussian: return x => a * Math.Exp(-Math.Pow((x - b), 2));
                default:
                    throw new ArgumentException("Requested function is not cartesian", nameof(id));
            }
        }

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