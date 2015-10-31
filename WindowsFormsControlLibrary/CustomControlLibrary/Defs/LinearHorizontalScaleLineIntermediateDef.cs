using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class LinearHorizontalScaleLineIntermediateDef {
        public LinearHorizontalScaleLineIntermediateDef() {
            this.Enabled = true;
            this.ForeColor = Color.Gray;
            this.Start = new Point(25, 25);
            this.Length = 400;
            this.TickLength = 6;
            this.TickWidth = 1;
        }

        public LinearHorizontalScaleLineIntermediateDef(Boolean Enabled, Color ForeColor, Point Start, Int32 Length) {
            this.Enabled = Enabled;
            this.ForeColor = ForeColor;
            this.Start = Start;
            this.Length = Length;
            this.TickLength = 6;
            this.TickWidth = 1;
        }
        public Boolean Enabled { get; set; }
        public Color ForeColor { get; set; }
        public Point Start { get; set; }
        public Single Length { get; set; }
        public Single TickLength { get; set; }
        public Single TickWidth { get; set; }
    }
}
