using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_12
{
    internal class LineStyle
    {
        public Color Color { get; }
        public float Width { get; }
        public DashStyle DashStyle { get; }

        public LineStyle(Color color, float width = 2f, DashStyle dashStyle = DashStyle.Solid)
        {
            this.Color = color;
            this.Width = width;
            this.DashStyle = dashStyle;
        }

        public static LineStyle Default => new LineStyle(Color.Blue, 2f, DashStyle.Solid);
    }
}
