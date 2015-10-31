using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class VerticalNeedleRenederer {
        public static void RenderVerticalNeedle(this Graphics Graphics, Rectangle ClientRectangle, Point Start, Single Length, Int32 NeedleLength, Int32 NeedleWidth, Single MinimumValue, Single MaximumValue, NeedleTypeEnum NeedleType, Color ForeColor, Single Value) {
            var valueAbsolute = Math.Abs(MaximumValue - MinimumValue);
            var scaleAdjustment = (Single)Math.Abs(Length / valueAbsolute);
            var scaleZeroAdjustment = (Single)(0 - MinimumValue) * scaleAdjustment;
            var adjustedNeedleValue = (Single)(Value * scaleAdjustment);

            Graphics.SetClip(ClientRectangle);
            Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            switch (NeedleType) {
                case NeedleTypeEnum.Beveled: {
                        var drawArrowTip = true;
                        var drawArrowBevels = true;
                        var drawArrowButt = true;

                        var brushAngle = 180;

                        var subcol1 = (Int32)(((brushAngle + 225) % 180) * 100 / 180);
                        var subcol2 = (Int32)(((brushAngle + 135) % 180) * 100 / 180);

                        var x = Start.X;
                        var y = (Single)((Start.Y + ((MaximumValue - Value) * scaleAdjustment)));

                        if (drawArrowTip) {
                            var points = new PointF[2];
                            points[0].X = (Single)(x);
                            points[0].Y = (Single)(y);

                            points[1].X = (Single)(x + NeedleLength);
                            points[1].Y = (Single)(y);

                            using (var pen = new Pen(ForeColor, 1)) {
                                Graphics.DrawLine(pen, points[0].X, points[0].Y, points[1].X, points[1].Y);
                            }
                        }

                        if (drawArrowBevels) {
                            using (var brushLight = new SolidBrush(Color.FromArgb(180 - subcol1, 180 - subcol1, 180 - subcol1)))
                            using (var brushDark = new SolidBrush(Color.FromArgb(80 + subcol1, 80 + subcol1, 80 + subcol1))) {
                                var pointsDark = new PointF[3];

                                pointsDark[0].X = (Single)(x + NeedleLength);
                                pointsDark[0].Y = (Single)(y + (NeedleWidth * 2));

                                pointsDark[1].X = (Single)(x + NeedleLength);
                                pointsDark[1].Y = (Single)(y);

                                pointsDark[2].X = (Single)(x);
                                pointsDark[2].Y = (Single)(y);

                                Graphics.FillPolygon(brushDark, pointsDark);

                                var pointsLight = new PointF[3];
                                pointsLight[0].X = (Single)(x + NeedleLength);
                                pointsLight[0].Y = (Single)(y - (NeedleWidth * 2));

                                pointsLight[1].X = (Single)(x + NeedleLength);
                                pointsLight[1].Y = (Single)(y);

                                pointsLight[2].X = (Single)(x);
                                pointsLight[2].Y = (Single)(y);

                                Graphics.FillPolygon(brushLight, pointsLight);
                            }
                        }

                        if (drawArrowButt) {
                            using (var brushButt = new SolidBrush(Color.FromArgb(180 - subcol2, 180 - subcol2, 180 - subcol2))) {
                                var pointsBut = new PointF[3];

                                pointsBut[0].X = (Single)(x + NeedleLength);
                                pointsBut[0].Y = (Single)(y - (NeedleWidth * 2));

                                pointsBut[1].X = (Single)(x + NeedleLength);
                                pointsBut[1].Y = (Single)(y + (NeedleWidth * 2));

                                pointsBut[2].X = (Single)(x + NeedleLength - (NeedleWidth * 4));
                                pointsBut[2].Y = (Single)(y);

                                Graphics.FillPolygon(brushButt, pointsBut);
                            }
                        }
                        break;
                    }
                case NeedleTypeEnum.Flat: {
                        var x = (Single)(Start.X - (NeedleWidth / 2));
                        var y = (Single)((Start.Y + ((MaximumValue - Value) * scaleAdjustment)));
                        var width = (Single)NeedleLength;
                        var height = (Single)NeedleWidth;

                        using (var solidBrush = new SolidBrush(ForeColor)) {
                            Graphics.FillRectangle(solidBrush, new RectangleF((x + (width - (width / 4))), (y - (height / 2)), (width / 4), (height * 2)));
                            Graphics.FillRectangle(solidBrush, new RectangleF(x, y, width, height));
                        }
                        break;
                    }
            }
        }
    }
}
