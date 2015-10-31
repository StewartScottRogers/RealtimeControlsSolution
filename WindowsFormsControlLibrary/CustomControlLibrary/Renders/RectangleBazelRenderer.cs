using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    public static class RectangleBazelRenderer {
        public static Rectangle RenderNonFocusedRectangleBezel(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor) {
            using (var pen = new Pen(BackGroundColor.MakeShaded(40), 1)) {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                pen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
                Graphics.DrawRectangle(pen, ClientRectangle);
                var reducedRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
                reducedRectangle.Inflate(-1, -1);
                return reducedRectangle;       
            }
        }
        public static Rectangle RenderFocusedRectangleBezel(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor) {
            using (var pen = new Pen(BackGroundColor.MakeHilighted(40), 1)) {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                pen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
                Graphics.DrawRectangle(pen, ClientRectangle);
                var reducedRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
                reducedRectangle.Inflate(-1, -1);
                return reducedRectangle;
            }
        }
    }
}