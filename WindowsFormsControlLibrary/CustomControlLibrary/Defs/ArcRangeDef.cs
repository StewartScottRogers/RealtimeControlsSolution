using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class ArcRangeDef {
        public ArcRangeDef() {
            this.Enabled = false;
            this.InnerRadius = 30;
            this.OuterRadius = 35;
            this.StartValue = 10;
            this.EndValue = 100;
            this.ForeColor = Color.Red;
        }

        public ArcRangeDef(Boolean Enabled, Int32 InnerRadius, Int32 OuterRadius, Single StartValue, Single EndValue, Color ForeColor) {
            this.Enabled = Enabled;
            this.InnerRadius = InnerRadius;
            this.OuterRadius = OuterRadius;
            this.StartValue = StartValue;
            this.EndValue = EndValue;
            this.ForeColor = ForeColor;
        }

        public bool Enabled { get; set; }
        public Int32 InnerRadius { get; set; }
        public Int32 OuterRadius { get; set; }
        public Single StartValue { get; set; }
        public Single EndValue { get; set; }
        public Color ForeColor { get; set; }
    }
}
