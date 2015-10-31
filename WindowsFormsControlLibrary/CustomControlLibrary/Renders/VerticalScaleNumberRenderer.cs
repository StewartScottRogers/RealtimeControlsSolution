using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class VerticalScaleNumberRenderer {
        public static void RenderVerticalScaleNumbers(
                                                        this Graphics Graphics,
                                                        Rectangle ClientRectangle,
                                                        Font Font,
                                                        Color ForeColor,
                                                        FontBound.BoundDef FontBound,
                                                        String Format,
                                                        Single MinimumValue,
                                                        Single MaximumValue,
                                                        Single MajorStepValue,
                                                        Point Start,
                                                        Single Length
            ) {
            var absoluteLength = Math.Abs((MaximumValue - MinimumValue));
            var adjustmentValue = (Single)(Length / absoluteLength);
            var adjustedMajorStepValue = (Single)(MajorStepValue * adjustmentValue);

            Graphics.SetClip(ClientRectangle);
            Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var index = (Single)Start.Y + Length;
            var numberValue = MinimumValue;

            while (index >= (Single)Start.Y - adjustedMajorStepValue) {
                var valueText = (numberValue).ToString(Format);
                var boundingBox = Graphics.MeasureString(valueText, Font, -1, StringFormat.GenericTypographic);

                Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                var x = Start.X;
                var y = index - ((FontBound.Y2 - FontBound.Y1) / 2) + 1;

                using (var solidBrush = new SolidBrush(ForeColor)) {
                    Graphics.DrawString(
                                            valueText,
                                            Font,
                                            solidBrush,
                                            x,
                                            y,
                                            StringFormat.GenericTypographic
                                       );
                }

                index -= adjustedMajorStepValue;
                numberValue += MajorStepValue;
            }

            Graphics.ResetTransform();
        }
    }
}
