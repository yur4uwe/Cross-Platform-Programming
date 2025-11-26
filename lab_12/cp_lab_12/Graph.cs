using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace cp_lab_12
{
    internal class Graph
    {
        private readonly List<Plot> plots = new List<Plot>();

        // margins in pixels
        private const int marginLeft = 50;
        private const int marginRight = 16;
        private const int marginTop = 16;
        private const int marginBottom = 40;

        public void AddPlot(Plot p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            plots.Add(p);
        }

        public void ClearPlots()
        {
            plots.Clear();
        }

        public void Draw(Graphics g, Rectangle bounds)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));

            // compute data bounds
            double xmin = double.PositiveInfinity, xmax = double.NegativeInfinity;
            double ymin = double.PositiveInfinity, ymax = double.NegativeInfinity;

            foreach (var p in plots)
            {
                p.GetBounds(out double pxmin, out double pxmax, out double pymin, out double pymax);
                if (double.IsNaN(pxmin) || double.IsNaN(pymin)) continue;
                if (pxmin < xmin) xmin = pxmin;
                if (pxmax > xmax) xmax = pxmax;
                if (pymin < ymin) ymin = pymin;
                if (pymax > ymax) ymax = pymax;
            }

            if (double.IsInfinity(xmin) || double.IsInfinity(ymin))
            {
                g.Clear(Color.White);
                return;
            }

            if (xmin - xmax < 1e-7)
            {
                xmin -= 0.5; xmax += 0.5;
            }
            if (ymin - ymax < 1e-7)
            {
                ymin -= 0.5; ymax += 0.5;
            }

            // drawing area
            var plotLeft = bounds.Left + marginLeft;
            var plotTop = bounds.Top + marginTop;
            var plotWidth = Math.Max(1, bounds.Width - marginLeft - marginRight);
            var plotHeight = Math.Max(1, bounds.Height - marginTop - marginBottom);
            var plotRect = new Rectangle(plotLeft, plotTop, plotWidth, plotHeight);

            // background
            g.Clear(Color.White);
            using (var bgBrush = new SolidBrush(Color.FromArgb(250, 250, 250)))
            {
                g.FillRectangle(bgBrush, plotRect);
            }

            // coordinate transforms
            float tx(double x) => (float)(plotLeft + (x - xmin) / (xmax - xmin) * plotWidth);
            float ty(double y) => (float)(plotTop + plotHeight - (y - ymin) / (ymax - ymin) * plotHeight);

            // ticks
            int xticks = 6;
            int yticks = 6;

            // draw grid at ticks (behind axes & plots)
            using (var gridPen = new Pen(Color.FromArgb(220, 220, 220), 1f))
            {
                gridPen.DashStyle = DashStyle.Solid;
                // vertical grid lines (x ticks)
                for (int i = 0; i < xticks; i++)
                {
                    double xv = xmin + (xmax - xmin) * i / xticks;
                    float px = tx(xv);
                    g.DrawLine(gridPen, px, plotTop, px, plotTop + plotHeight);
                }

                // horizontal grid lines (y ticks)
                for (int i = 0; i < yticks; i++)
                {
                    double yv = ymin + (ymax - ymin) * i / yticks;
                    float py = ty(yv);
                    g.DrawLine(gridPen, plotLeft, py, plotLeft + plotWidth, py);
                }
            }

            bool isYaxisInsidePlot = (ymin <= 0.0 && 0.0 <= ymax);
            bool isXaxisInsidePlot = (xmin <= 0.0 && 0.0 <= xmax);

            float axisYPixColumn = isYaxisInsidePlot ? tx(0.0) : plotLeft;
            float axisXPixRow = isXaxisInsidePlot ? ty(0.0) : (plotTop + plotHeight);

            using (var axisPen = new Pen(Color.Black, 1f))
            {
                g.DrawLine(axisPen, axisYPixColumn, plotTop, axisYPixColumn, plotTop + plotHeight);
                g.DrawLine(axisPen, plotLeft, axisXPixRow, plotLeft + plotWidth, axisXPixRow);
            }

            // ticks, tick marks and labels
            using (var font = new Font("Segoe UI", 8f))
            using (var textBrush = new SolidBrush(Color.Black))
            {
                // x ticks (labels below or above axis depending on axis position)
                for (int i = 0; i <= xticks; i++)
                {
                    double xv = xmin + (xmax - xmin) * i / xticks;
                    float px = tx(xv);
                    float pyTickStart = axisXPixRow;
                    float pyTickEnd = axisXPixRow + 4f;
                    // if axis is at top, draw tick downward; if axis at bottom, draw downward too; keep consistent
                    if (axisXPixRow <= plotTop + 2) // near top
                    {
                        pyTickStart = axisXPixRow;
                        pyTickEnd = axisXPixRow + 4f;
                    }
                    else
                    {
                        pyTickStart = axisXPixRow;
                        pyTickEnd = axisXPixRow + 4f;
                    }

                    g.DrawLine(Pens.Black, px, pyTickStart, px, pyTickEnd);

                    string label = xv.ToString("0.###");
                    var sz = g.MeasureString(label, font);
                    // place label below the axis if axis is at top or bottom; slight offset
                    float labelY = axisXPixRow + 4f;
                    if (labelY + sz.Height > plotTop + plotHeight) // if beyond bottom, draw above ticks
                    {
                        labelY = axisXPixRow  - 4f - sz.Height;
                    }
                    g.DrawString(label, font, textBrush, px - sz.Width / 2f, labelY);
                }

                // y ticks (labels to left of axis)
                for (int i = 0; i <= yticks; i++)
                {
                    double yv = ymin + (ymax - ymin) * i / yticks;
                    float py = ty(yv);
                    float pxTickStart = axisYPixColumn;
                    float pxTickEnd = axisYPixColumn - 4f;
                    g.DrawLine(Pens.Black, pxTickStart, py, pxTickEnd, py);

                    string label = yv.ToString("0.###");
                    var sz = g.MeasureString(label, font);
                    // place label to the left of tick line, with margin
                    float labelX = axisYPixColumn - sz.Width - 6f;
                    if (labelX < plotLeft - 40) // ensure not overlapped with left margin text area
                    {
                        labelX = plotLeft - sz.Width - 6f;
                    }
                    g.DrawString(label, font, textBrush, labelX, py - sz.Height / 2f);
                }
            }

            foreach (var p in plots)
            {
                p.Draw(g, tx, ty);
            }

            using (var borderPen = new Pen(Color.Gray, 1f))
            {
                g.DrawRectangle(borderPen, plotRect);
            }
        }
    }
}
