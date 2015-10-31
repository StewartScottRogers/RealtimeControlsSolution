using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class ArcRangeRenderer {       
        public static void ArcRenderRanges(this Graphics Graphics, Rectangle ClientRectangle, Point Center, Int32 ArcStart, Int32 ArcSweep, Single MinimumValue, Single MaximumValue, ArcRangeDef[] Ranges) {
            for (Int32 index = 0; index < Ranges.Length; index++)
                Graphics.ArcRenderRange(ClientRectangle, Center, ArcStart, ArcSweep, MinimumValue, MaximumValue, Ranges[index]);
        }

        private static void ArcRenderRange(this Graphics Graphics, Rectangle ClientRectangle, Point Center, Int32 ArcStart, Int32 ArcSweep, Single MinimumValue, Single MaximumValue, ArcRangeDef Range) {
            Graphics.SetClip(ClientRectangle);
            Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var graphicsPath = new GraphicsPath()) {
                if (Range.EndValue > Range.StartValue && Range.Enabled) {
                    var rangeStartAngle = ArcStart + (Range.StartValue - MinimumValue) * ArcSweep / (MaximumValue - MinimumValue);
                    var rangeSweepAngle = (Range.EndValue - Range.StartValue) * ArcSweep / (MaximumValue - MinimumValue);
                    graphicsPath.Reset();
                    graphicsPath.AddPie(new Rectangle(Center.X - Range.OuterRadius, Center.Y - Range.OuterRadius, 2 * Range.OuterRadius, 2 * Range.OuterRadius), rangeStartAngle, rangeSweepAngle);
                    graphicsPath.Reverse();
                    graphicsPath.AddPie(new Rectangle(Center.X - Range.InnerRadius, Center.Y - Range.InnerRadius, 2 * Range.InnerRadius, 2 * Range.InnerRadius), rangeStartAngle, rangeSweepAngle);
                    graphicsPath.Reverse();
                    Graphics.SetClip(graphicsPath);
                    using (var solidBrush = new SolidBrush(Range.ForeColor)) {
                        Graphics.FillPie(solidBrush, new Rectangle(Center.X - Range.OuterRadius, Center.Y - Range.OuterRadius, 2 * Range.OuterRadius, 2 * Range.OuterRadius), rangeStartAngle, rangeSweepAngle);
                    }
                }
            }
        }
    }
}
