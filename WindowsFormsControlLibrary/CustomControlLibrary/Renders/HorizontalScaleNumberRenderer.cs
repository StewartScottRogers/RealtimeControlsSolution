using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class HorizontalScaleNumberRenderer {
        public static void RenderHorizontalScaleNumbers(
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

            var index = (Single)Start.X;
            var numberValue = MinimumValue;

            while (index <= (Single)Start.X + Length + 5) {
                var valueText = (numberValue).ToString(Format);
                var boundingBox = Graphics.MeasureString(valueText, Font, -1, StringFormat.GenericTypographic);

                Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                using (var solidBrush = new SolidBrush(ForeColor)) {
                    Graphics.DrawString(
                                            valueText,
                                            Font,
                                            solidBrush,
                                            index - (boundingBox.Width / 2),
                                            Start.Y,
                                            StringFormat.GenericTypographic
                                       );
                }

                index += adjustedMajorStepValue;
                numberValue += MajorStepValue;
            }

            Graphics.ResetTransform();
        }
    }
}
