using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class VerticalBandRenderer {
        public static void RenderVerticalBand(this Graphics Graphics, Rectangle ClientRectangle, Point Start, Int32 Length, Int32 Width, Color ForeColor) {           
            Graphics.SetClip(ClientRectangle);
            Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var solidBrush = new SolidBrush(ForeColor)) {
                Graphics.FillRectangle(solidBrush, new RectangleF(Start.X, Start.Y, Width, Length));
            }
        }
    }
}
