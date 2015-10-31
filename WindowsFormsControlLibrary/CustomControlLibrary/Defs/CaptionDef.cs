using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal class CaptionDef {
        public CaptionDef() {
            this.Position = new Point(10, 10);
            this.Text = String.Empty;
            this.ForeColor = Color.Black;
            this.Visible = false;
        }
        public CaptionDef(Point Position, String Text, Color ForeColor, Boolean Visible) {
            this.Position = Position;
            this.Text = Text;
            this.ForeColor = ForeColor;
            this.Visible = Visible;
        }
        public Point Position { get; set; }
        public String Text { get; set; }
        public Color ForeColor { get; set; }
        public Boolean Visible { get; set; }
    }

}
