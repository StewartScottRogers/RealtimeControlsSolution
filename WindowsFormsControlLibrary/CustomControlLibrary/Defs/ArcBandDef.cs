using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class ArcBandDef {
        public ArcBandDef() {
            this.Color = Color.Gray;
            this.Radius = 80;
            this.Start = 135;
            this.Sweep = 270;
            this.Width = 2;
        }

        public Color Color { get; set; }
        public Int32 Radius { get; set; }
        public Int32 Start { get; set; }
        public Int32 Sweep { get; set; }
        public Int32 Width { get; set; }
    }
}
