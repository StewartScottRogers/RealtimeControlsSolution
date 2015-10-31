using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class LinearHorizontalRangeDef {
        public LinearHorizontalRangeDef() {
            this.Enabled = false;
            this.ForeColor = Color.Red;
            this.Start = 0;
            this.End = 15;
            this.Width = 10;           
        }
        public LinearHorizontalRangeDef(Boolean Enabled, Single Start, Single End, Int32 Width, Color ForeColor) {
            this.Enabled = Enabled;
            this.ForeColor = ForeColor;
            this.Start = Start;
            this.End = End;
            this.Width = Width;            
        }

        public bool Enabled { get; set; }
        public Color ForeColor { get; set; }
        public Single Start { get; set; }
        public Single End { get; set; }
        public Int32 Width { get; set; }
    }
}
