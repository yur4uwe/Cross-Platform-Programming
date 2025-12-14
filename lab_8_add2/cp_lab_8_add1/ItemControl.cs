using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cp_lab_8_add1
{
    public class ItemControl : UserControl
    {
        private readonly Label lblName;
        private readonly Label lblValue;
        private readonly System.Windows.Forms.ToolTip tooltip;
        public Item Item { get; }

        public ItemControl(Item item)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));

            this.Size = new Size(80, 80);
            this.DoubleBuffered = true;
            this.BorderStyle = BorderStyle.FixedSingle;

            this.BackColor = RarityToColor(Item.Rarity);

            lblName = new Label
            {
                Text = Item.Name,
                Dock = DockStyle.Top,
                Height = 54,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(SystemFonts.DefaultFont.FontFamily, 10f, FontStyle.Bold),
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                AutoSize = false
            };

            lblValue = new Label
            {
                Text = $"{Item.Value} gold",
                Dock = DockStyle.Bottom,
                Height = 28,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(SystemFonts.DefaultFont.FontFamily, 9f, FontStyle.Regular),
                BackColor = Color.Transparent
            };

            var fg = GetReadableForeColor(this.BackColor);
            lblName.ForeColor = fg;
            lblValue.ForeColor = fg;

            tooltip = new System.Windows.Forms.ToolTip
            {
                IsBalloon = false,
                ShowAlways = true,
                InitialDelay = 300,
                ReshowDelay = 100,
                AutoPopDelay = 5000
            };

            tooltip.SetToolTip(this, Item.Name);
            tooltip.SetToolTip(lblName, Item.Name);

            this.Controls.Add(lblValue);
            this.Controls.Add(lblName);
        }

        private static Color RarityToColor(Rarity r)
        {
            switch (r)
            {
                case Rarity.Common: return Color.FromArgb(0xE0, 0xE0, 0xE0);  
                case Rarity.Uncommon: return Color.FromArgb(0x7C, 0xFF, 0x7C); 
                case Rarity.Rare: return Color.FromArgb(0x7C, 0x9B, 0xFF);    
                case Rarity.Epic: return Color.FromArgb(0xB6, 0x7C, 0xFF);    
                case Rarity.Legendary: return Color.FromArgb(0xFF, 0xC1, 0x7C); 
                default: return SystemColors.Control;
            }
        }

        private static Color GetReadableForeColor(Color back)
        {
            double luminance = (0.2126 * back.R + 0.7152 * back.G + 0.0722 * back.B) / 255;
            return luminance > 0.6 ? Color.Black : Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(ControlPaint.Dark(this.BackColor)))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
