using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class ArcScaleNumberDef {
        public ArcScaleNumberDef() {
            Radius = 95;
            Color = Color.Black;
            Format = "";
            StartScaleLine = 0;
            StepScaleLines = 1;
            Orientation = ArcOriantationTypeEnum.Horizontal;
        }
        public Int32 Radius { get; set; }
        public Color Color { get; set; }
        public String Format { get; set; }
        public Int32 StartScaleLine { get; set; }
        public Int32 StepScaleLines { get; set; }
        public ArcOriantationTypeEnum Orientation { get; set; }
    }
}
