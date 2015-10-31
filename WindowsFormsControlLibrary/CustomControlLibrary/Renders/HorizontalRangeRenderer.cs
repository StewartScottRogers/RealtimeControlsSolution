using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class HorizontalRangeRenderer {
        public static void RenderHorizontalRanges(this Graphics Graphics, Rectangle ClientRectangle, Point Start, Int32 Length, Single MinimumValue, Single MaximumValue, LinearHorizontalRangeDef[] Ranges) {
            for (Int32 index = 0; index < Ranges.Length; index++)
                Graphics.RenderHorizontalRanges(ClientRectangle, Start, Length, MinimumValue, MaximumValue, Ranges[index]);
        }
        private static void RenderHorizontalRanges(this Graphics Graphics, Rectangle ClientRectangle, Point Start, Int32 Length, Single MinimumValue, Single MaximumValue, LinearHorizontalRangeDef Range) {
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

            var x = (Single)((Start.X + scaleLength) + rangeStart);
            var y = (Single)Start.Y;
            var width = (Single)rangeLength;
            var height = (Single)Range.Width;
            
            using (var solidBrush = new SolidBrush(Range.ForeColor)) {
                Graphics.FillRectangle(solidBrush, new RectangleF(x, y, width, height));
            }
        }
    }
}
