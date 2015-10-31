using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class LinearVerticalBandDef {
        public LinearVerticalBandDef() {
            this.ForeColor = Color.Gray;
            this.Start = new Point(25, 25);
            this.Length = 400;
            this.Width = 2;
        }

        public LinearVerticalBandDef(Point Start, Int32 Length) {
            this.ForeColor = Color.Gray;
            this.Start = Start;
            this.Length = Length;
            this.Width = 2;
        }

        public Color ForeColor { get; set; }
        public Point Start { get; set; }
        public Int32 Length { get; set; }
        public Int32 Width { get; set; }
    }
}
