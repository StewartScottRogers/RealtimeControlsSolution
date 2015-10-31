using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class LinearHorizontalScaleLineMajorDef {
        public LinearHorizontalScaleLineMajorDef() {
            this.Enabled = true;
            this.ForeColor = Color.Black;
            this.Start = new Point(25, 25);
            this.Length = 400;
            this.TickLength = 10;
            this.TickWidth = 1;
            this.StepValue = 50.0f;
        }

        public LinearHorizontalScaleLineMajorDef(Boolean Enabled, Color ForeColor,  Point Start, Int32 Length) {
            this.Enabled = Enabled;
            this.ForeColor = ForeColor;
            this.Start = Start;
            this.Length = Length;
            this.TickLength = 10;
            this.TickWidth = 1;
            this.StepValue = 50.0f;
        }
        public Boolean Enabled { get; set; }
        public Color ForeColor { get; set; }
        public Point Start { get; set; }
        public Single Length { get; set; }
        public Single TickLength { get; set; }
        public Single TickWidth { get; set; }
        public Single StepValue { get; set; }
    }
}
