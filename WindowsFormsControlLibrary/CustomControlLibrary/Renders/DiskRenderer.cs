using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class DiskRenderer {
        public static void RenderNonFocusedRaisedDisk(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderNonFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderRaisedDisk(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderNonFocusedDepressedDisk(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderNonFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderDepressedDisk(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderFocusedRaisedDisk(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderRaisedDisk(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderFocusedDepressedDisk(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderDepressedDisk(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderRaisedDisk(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            using (var darkPen = new Pen(BackGroundColor.MakeShaded(50), Depth))
            using (var lightPen = new Pen(BackGroundColor.MakeHilighted(50), Depth)) {
                Graphics.DrawArc(darkPen, ClientRectangle, -45, 180);
                Graphics.DrawArc(lightPen, ClientRectangle, 135, 180);
            }
        }
        public static void RenderDepressedDisk(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            using (var darkPen = new Pen(BackGroundColor.MakeShaded(50), Depth))
            using (var lightPen = new Pen(BackGroundColor.MakeHilighted(50), Depth)) {
                Graphics.DrawArc(lightPen, ClientRectangle, -45, 180);
                Graphics.DrawArc(darkPen, ClientRectangle, 135, 180);
            }
        }

    }
}
