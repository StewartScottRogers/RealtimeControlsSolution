using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class LinearVerticalScaleNumberDef {
        public LinearVerticalScaleNumberDef() {
            this.Enabled = true;
            this.Start = new Point(5, 25);
            this.Length = 400;
            this.ForeColor = Color.Black;
            this.Format = "";
            this.Orientation = LinearVerticalOriantationTypeEnum.Right;
        }

        public LinearVerticalScaleNumberDef(Point Start, Single Length, LinearVerticalOriantationTypeEnum Orientation) {
            this.Enabled = true;
            this.Start = Start;
            this.Length = Length;
            this.ForeColor = Color.Black;
            this.Format = "";
            this.Orientation = Orientation;
        }
        public Boolean Enabled { get; set; }
        public Point Start { get; set; }
        public Single Length { get; set; }
        public Color ForeColor { get; set; }
        public String Format { get; set; }
        public LinearVerticalOriantationTypeEnum Orientation { get; set; }
    }
}
