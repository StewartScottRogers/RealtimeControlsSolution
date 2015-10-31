using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary {
    internal static class ArcScaleNumberRenderer {
        public static void RenderArcScaleNumbers(
                                                    this Graphics graphics, 
                                                    Rectangle ClientRectangle, 
                                                    Font Font,
                                                    Color ForeColor,
                                                    FontBound.BoundDef FontBound, 
                                                    Point Center, 
                                                    Int32 Radius, 
                                                    Single MinimumValue,
                                                    Single MaximumValue, 
                                                    String Format,                                                     
                                                    Int32 StartScaleLine,
                                                    Single MajorStepValue,
                                                    Int32 ArcStart,
                                                    Int32 ArcSweep, 
                                                    ArcOriantationTypeEnum Orientation
            ) {
            using (var graphicsPath = new GraphicsPath()) {
                graphics.SetClip(ClientRectangle);

                Single countValue = 0;
                Int32 counter1 = 0;
                while (countValue <= (MaximumValue - MinimumValue)) {
                    graphics.ResetTransform();
                    graphicsPath.Reset();

                    var valueText = (MinimumValue + countValue).ToString(Format);
                    var boundingBox = graphics.MeasureString(valueText, Font, -1, StringFormat.GenericTypographic);

                    if (Orientation != ArcOriantationTypeEnum.Horizontal) {
                        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        graphics.RotateTransform(90.0F + ArcStart + countValue * ArcSweep / (MaximumValue - MinimumValue));
                    }

                    graphics.TranslateTransform(
                                                    (Single)(Center.X + Radius * Math.Cos((ArcStart + countValue * ArcSweep / (MaximumValue - MinimumValue)) * Math.PI / 180.0f)),
                                                    (Single)(Center.Y + Radius * Math.Sin((ArcStart + countValue * ArcSweep / (MaximumValue - MinimumValue)) * Math.PI / 180.0f)),
                                                    System.Drawing.Drawing2D.MatrixOrder.Append
                                               );

                    if (counter1 >= StartScaleLine - 1)
                        graphics.DrawString(valueText, Font, new SolidBrush(ForeColor), -boundingBox.Width / 2, -FontBound.Y1 - (FontBound.Y2 - FontBound.Y1 + 1) / 2, StringFormat.GenericTypographic);

                    countValue += MajorStepValue;
                    counter1++;

                    graphics.ResetTransform();
                }
            }         
        }
    }
}
