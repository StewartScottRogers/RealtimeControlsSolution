using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class RectangleButtonRenderer {
        public static void RenderNonFocusedRaisedRectangleButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderNonFocusedRectangleBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderRaisedRectangleButton(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderNonFocusedDepressedRectangleButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderNonFocusedRectangleBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderDepressedRectangleButton(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderFocusedRaisedRectangleButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderFocusedRectangleBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderRaisedRectangleButton(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderFocusedDepressedRectangleButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderFocusedRectangleBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderDepressedRectangleButton(reducedRectangle, BackGroundColor, Depth);
        }
        private static void RenderDepressedRectangleButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            using (var pen = new Pen(BackGroundColor, Depth))
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, BackGroundColor.MakeShaded(50), BackGroundColor.MakeHilighted(10), LinearGradientMode.ForwardDiagonal)) {
                Graphics.FillRectangle(brush, ClientRectangle);
                var originalSmoothingMode = Graphics.SmoothingMode;
                try {
                    Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Graphics.DrawRectangle(pen, ClientRectangle);
                } finally {
                    Graphics.SmoothingMode = originalSmoothingMode;
                }
            }
            Graphics.RenderRectangle(ClientRectangle, BackGroundColor.MakeShaded(15), Depth);
        }
        public static void RenderRaisedRectangleButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            using (var pen = new Pen(BackGroundColor, Depth))
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, BackGroundColor.MakeHilighted(10), BackGroundColor.MakeShaded(50), LinearGradientMode.ForwardDiagonal)) {
                Graphics.FillRectangle(brush, ClientRectangle);
                var originalSmoothingMode = Graphics.SmoothingMode;
                try {
                    Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Graphics.DrawRectangle(pen, ClientRectangle);
                } finally {
                    Graphics.SmoothingMode = originalSmoothingMode;
                }
            }
            Graphics.RenderRectangle(ClientRectangle, BackGroundColor.MakeShaded(7), Depth);
        }

        private static void RenderRectangle(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            using (var solidBrush = new SolidBrush(BackGroundColor)) {
                Graphics.FillRectangle(solidBrush, ClientRectangle.Deflate((Int32)Depth, (Int32)Depth));
            }
        }
    }
}
