using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class CircularSignalRenderer {   
        public static void RenderCircularSignal(this Graphics Graphics, Rectangle ClientRectangle, Color BackGroundColor, Single Depth = 1) {
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
        }
    }
}
