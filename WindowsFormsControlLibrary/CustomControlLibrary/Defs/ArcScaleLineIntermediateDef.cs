using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class ArcScaleLineIntermediateDef {
        public ArcScaleLineIntermediateDef() {
            TickForeColor = Color.Black;
            TickInnerRadius = 70;
            TickOuterRadius = 80;
            TickWidth = 1;
        }

        public Color TickForeColor { get; set; }
        public Int32 TickInnerRadius { get; set; }
        public Int32 TickOuterRadius { get; set; }
        public Int32 TickWidth { get; set; }
    }
}
