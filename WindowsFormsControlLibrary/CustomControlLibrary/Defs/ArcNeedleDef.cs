using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class ArcNeedleDef {
        public ArcNeedleDef() {
            this.Center = new Point(110, 110);
            this.Type = NeedleTypeEnum.Beveled;
            this.Radius = 80;
            this.Color = Color.DimGray;
            this.Width = 2;
        }

        public Point Center { get; set; }
        public NeedleTypeEnum Type { get; set; }
        public Int32 Radius { get; set; }
        public Color Color { get; set; }
        public Int32 Width { get; set; }
    }
}
