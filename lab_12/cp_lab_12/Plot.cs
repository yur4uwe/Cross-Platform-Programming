using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace cp_lab_12
{
    internal class Plot
    {
        private readonly double[] xData;
        private readonly double[] yData;
        public LineStyle Style { get; }

        public Plot(double[] x, double[] y, LineStyle style)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            if (x.Length != y.Length)
            {
                throw new ArgumentException("X and Y data arrays must have the same length.");
            }

            this.xData = (double[])x.Clone();
            this.yData = (double[])y.Clone();
            this.Style = style ?? LineStyle.Default;
        }

        public int PointCount => xData.Length;

        public double X(int i) => xData[i];
        public double Y(int i) => yData[i];

        public void GetBounds(out double xmin, out double xmax, out double ymin, out double ymax)
        {
            if (xData.Length == 0)
            {
                xmin = xmax = ymin = ymax = 0;
                return;
            }

            xmin = xmax = xData[0];
            ymin = ymax = yData[0];

            for (int i = 1; i < xData.Length; i++)
            {
                if (xData[i] < xmin) xmin = xData[i];
                if (xData[i] > xmax) xmax = xData[i];
                if (yData[i] < ymin) ymin = yData[i];
                if (yData[i] > ymax) ymax = yData[i];
            }
        }

        public void Draw(Graphics g, Func<double, float> tx, Func<double, float> ty)
        {
            if (PointCount == 0) return;

            var pen = new Pen(Style.Color, Style.Width)
            {
                DashStyle = Style.DashStyle
            };

            g.SmoothingMode = SmoothingMode.AntiAlias;
            PointF prevPoint = new PointF(0, 0);
            for (int i = 0; i < PointCount; i++)
            {
                var pt = new PointF(tx(X(i)), ty(Y(i)));
                if (Style.DashStyle == DashStyle.Dot)
                {
                    g.FillEllipse(new SolidBrush(Style.Color), pt.X - Style.Width / 2, pt.Y - Style.Width / 2, Style.Width, Style.Width);
                }
                else if (i > 0)
                {
                    g.DrawLine(pen, prevPoint, pt);
                }
                prevPoint = pt;
            }
        }
    }
}
