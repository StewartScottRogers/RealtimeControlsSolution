using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class CircularButtonRenderer {
        public static void RenderNonFocusedRaisedCircularButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderNonFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderRaisedCircularButton(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderNonFocusedDepressedCircularButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderNonFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderDepressedCircularButton(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderFocusedRaisedCircularButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderRaisedCircularButton(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderFocusedDepressedCircularButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderDepressedCircularButton(reducedRectangle, BackGroundColor, Depth);
        }
        private static void RenderDepressedCircularButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            using (var pen = new Pen(BackGroundColor, Depth))
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, BackGroundColor.MakeShaded(50), BackGroundColor.MakeHilighted(10), LinearGradientMode.ForwardDiagonal)) {
                Graphics.FillEllipse(brush, ClientRectangle);
                var originalSmoothingMode = Graphics.SmoothingMode;
                try {
                    Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Graphics.DrawEllipse(pen, ClientRectangle);
                } finally {
                    Graphics.SmoothingMode = originalSmoothingMode;
                }
            }
            Graphics.RenderCircle(ClientRectangle, BackGroundColor.MakeShaded(15), Depth);
        }
        public static void RenderRaisedCircularButton(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            using (var pen = new Pen(BackGroundColor, Depth))
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, BackGroundColor.MakeHilighted(10), BackGroundColor.MakeShaded(50), LinearGradientMode.ForwardDiagonal)) {
                Graphics.FillEllipse(brush, ClientRectangle);
                var originalSmoothingMode = Graphics.SmoothingMode;
                try {
                    Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Graphics.DrawEllipse(pen, ClientRectangle);
                } finally {
                    Graphics.SmoothingMode = originalSmoothingMode;
                }
            }
            Graphics.RenderCircle(ClientRectangle, BackGroundColor.MakeShaded(7), Depth);
        }

        private static void RenderCircle(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            using (var solidBrush = new SolidBrush(BackGroundColor)) {
                Graphics.FillEllipse(solidBrush, ClientRectangle.Deflate((Int32)Depth, (Int32)Depth));
            }
        }
    }
}
