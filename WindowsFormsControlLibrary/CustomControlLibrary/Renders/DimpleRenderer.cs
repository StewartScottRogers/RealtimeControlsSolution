using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class DimpleRenderer {
        public static void RenderNonFocusedRaisedDimple(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {           
            var reducedRectangle = Graphics.RenderNonFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderRaisedDimple(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderNonFocusedDepressedDimple(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {           
            var reducedRectangle = Graphics.RenderNonFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderDepressedDimple(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderFocusedRaisedDimple(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {           
            var reducedRectangle = Graphics.RenderFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderNonFocusedRaisedDimple(reducedRectangle, BackGroundColor, Depth);
        }
        public static void RenderFocusedDepressedDimple(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            var reducedRectangle = Graphics.RenderFocusedRadialBezel(ClientRectangle, BackGroundColor);
            Graphics.RenderNonFocusedDepressedDimple(reducedRectangle, BackGroundColor, Depth);
        }

        public static void RenderRaisedDimple(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            using (var pen = new Pen(BackGroundColor, Depth))
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, BackGroundColor.MakeHilighted(55), BackGroundColor.MakeShaded(55), LinearGradientMode.ForwardDiagonal)) {
                Graphics.FillEllipse(brush, ClientRectangle);
                var originalSmoothingMode = Graphics.SmoothingMode;
                try {
                    Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Graphics.DrawEllipse(pen, ClientRectangle);
                } finally {
                    Graphics.SmoothingMode = originalSmoothingMode;
                }
            }
        }
        public static void RenderDepressedDimple(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
            using (var pen = new Pen(BackGroundColor, Depth))
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, BackGroundColor.MakeShaded(55), BackGroundColor.MakeHilighted(55), LinearGradientMode.ForwardDiagonal)) {
                Graphics.FillEllipse(brush, ClientRectangle);
                var originalSmoothingMode = Graphics.SmoothingMode;
                try {
                    Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Graphics.DrawEllipse(pen, ClientRectangle);
                } finally {
                    Graphics.SmoothingMode = originalSmoothingMode;
                }
            }
        }
    }
}
