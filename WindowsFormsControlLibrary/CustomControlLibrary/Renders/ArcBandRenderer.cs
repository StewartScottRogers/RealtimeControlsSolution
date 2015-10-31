using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class ArcBandRenderer {
        public static void RenderArcBand(this Graphics Graphics, Rectangle ClientRectangle, Point Center, Int32 ArcRadius, Int32 ArcStart, Int32 ArcSweep, Int32 Width, Color ForeColor) {
            Graphics.SetClip(ClientRectangle);
            Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            if (ArcRadius > 0)
                using (var pen = new Pen(ForeColor, Width)) {
                    Graphics.DrawArc(pen, new Rectangle(Center.X - ArcRadius, Center.Y - ArcRadius, 2 * ArcRadius, 2 * ArcRadius), ArcStart, ArcSweep);
                }
        }


    }
}
