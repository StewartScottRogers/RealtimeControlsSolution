using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class ArcScaleLineMajorDef {
        public ArcScaleLineMajorDef() {
            TickForeColor = Color.Black;
            TickInnerRadius = 73;
            TickOuterRadius = 80;
            TickWidth = 1;
            StepValue = 50.0f;
        }

        public Color TickForeColor { get; set; }
        public Int32 TickInnerRadius { get; set; }
        public Int32 TickOuterRadius { get; set; }
        public Int32 TickWidth { get; set; }
        public Single StepValue { get; set; }
    }
}
