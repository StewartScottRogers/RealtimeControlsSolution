using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class VerticalRangeRenderer {
        public static void RenderVerticalRanges(this Graphics Graphics, Rectangle ClientRectangle, Point Start, Int32 Length, Single MinimumValue, Single MaximumValue, LinearVerticalRangeDef[] Ranges) {
            for (Int32 index = 0; index < Ranges.Length; index++)
                Graphics.RenderVerticalRanges(ClientRectangle, Start, Length, MinimumValue, MaximumValue, Ranges[index]);
        }
        private static void RenderVerticalRanges(this Graphics Graphics, Rectangle ClientRectangle, Point Start, Int32 Length, Single MinimumValue, Single MaximumValue, LinearVerticalRangeDef Range) {
            if (!Range.Enabled)
                return;

            var valueAbsolute = Math.Abs(MaximumValue - MinimumValue);
            var scaleAdjustment = Math.Abs(Length / valueAbsolute);
            var scaleLength = (Length * scaleAdjustment);
            var rangeLength = Math.Abs((Range.End - Range.Start) * scaleAdjustment);
            var rangeStart = (Range.Start) * scaleAdjustment;
            var rangeEnd = (Range.End) * scaleAdjustment;

            Graphics.SetClip(ClientRectangle);
            Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var x = (Single)Start.X;
            var y = (Single)((Start.Y + ((MaximumValue - Range.End) * scaleAdjustment)));
            var width = (Single)Range.Width;
            var height = (Single)rangeLength;

            using (var solidBrush = new SolidBrush(Range.ForeColor)) {
                Graphics.FillRectangle(solidBrush, new RectangleF(x, y, width, height));
            }
        }
    }
}
