using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class LinearVerticalNeedleDef {
        public LinearVerticalNeedleDef(Point Start, Single Length) {
            this.Start = Start;
            this.Length = Length;
            this.Type = NeedleTypeEnum.Beveled;
            this.NeedleLength = 30;
            this.ForeColor = Color.DimGray;
            this.NeedleWidth = 2;
        }
        public Point Start { get; set; }
        public Single Length { get; set; }
        public NeedleTypeEnum Type { get; set; }
        public Int32 NeedleLength { get; set; }
        public Int32 NeedleWidth { get; set; }
        public Color ForeColor { get; set; }      
    }
}