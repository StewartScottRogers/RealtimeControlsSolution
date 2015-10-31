using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class ArcScaleLineMinorDef {
        public ArcScaleLineMinorDef() {
            TickForeColor = Color.Gray;
            TickInnerRadius = 75;
            TickOuterRadius = 80;
            TickWidth = 1;
            NumOfTicks = 9;
        }

        public Color TickForeColor { get; set; }
        public Int32 TickInnerRadius { get; set; }
        public Int32 TickOuterRadius { get; set; }
        public Int32 TickWidth { get; set; }
        public Int32 NumOfTicks { get; set; }
    }
}
