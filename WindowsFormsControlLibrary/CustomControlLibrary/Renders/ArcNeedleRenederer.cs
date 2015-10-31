using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class ArcNeedleRenederer {
        public static void RenderArcNeedle(this Graphics Graphics, Rectangle ClientRectangle, Point Center, Int32 Radius, Int32 Width, Single MinimumValue, Single MaximumValue, Int32 ArcStart, Int32 ArcSweep, NeedleTypeEnum NeedleType, Color ForeColor, Single Value) {
            Graphics.SetClip(ClientRectangle);
            Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            
            var brushAngle = (Int32)(ArcStart + (Value - MinimumValue) * ArcSweep / (MaximumValue - MinimumValue)) % 360;
            var needleAngle = brushAngle * Math.PI / 180;

            switch (NeedleType) {
                case NeedleTypeEnum.Beveled:
                    using (var pen = new Pen(ForeColor, Width)) {
                        var subcol1 = (Int32)(((brushAngle + 225) % 180) * 100 / 180);
                        var subcol2 = (Int32)(((brushAngle + 135) % 180) * 100 / 180);

                        var points = new PointF[3];
                        if (Math.Floor((Single)(((brushAngle + 225) % 360) / 180.0)) == 0) {
                            using (var brush1 = new SolidBrush(Color.FromArgb(180 - subcol1, 180 - subcol1, 180 - subcol1)))
                            using (var brush2 = new SolidBrush(Color.FromArgb(80 + subcol1, 80 + subcol1, 80 + subcol1))) {
                                points[0].X = (Single)(Center.X + Radius * Math.Cos(needleAngle));
                                points[0].Y = (Single)(Center.Y + Radius * Math.Sin(needleAngle));
                                points[1].X = (Single)(Center.X - Radius / 20 * Math.Cos(needleAngle));
                                points[1].Y = (Single)(Center.Y - Radius / 20 * Math.Sin(needleAngle));
                                points[2].X = (Single)(Center.X - Radius / 5 * Math.Cos(needleAngle) + Width * 2 * Math.Cos(needleAngle + Math.PI / 2));
                                points[2].Y = (Single)(Center.Y - Radius / 5 * Math.Sin(needleAngle) + Width * 2 * Math.Sin(needleAngle + Math.PI / 2));
                                Graphics.FillPolygon(brush1, points);

                                points[2].X = (Single)(Center.X - Radius / 5 * Math.Cos(needleAngle) + Width * 2 * Math.Cos(needleAngle - Math.PI / 2));
                                points[2].Y = (Single)(Center.Y - Radius / 5 * Math.Sin(needleAngle) + Width * 2 * Math.Sin(needleAngle - Math.PI / 2));
                                Graphics.FillPolygon(brush2, points);
                            }
                        } else {
                            using (var brush1 = new SolidBrush(Color.FromArgb(80 + subcol1, 80 + subcol1, 80 + subcol1)))
                            using (var brush2 = new SolidBrush(Color.FromArgb(180 - subcol1, 180 - subcol1, 180 - subcol1))) {
                                points[0].X = (Single)(Center.X + Radius * Math.Cos(needleAngle));
                                points[0].Y = (Single)(Center.Y + Radius * Math.Sin(needleAngle));
                                points[1].X = (Single)(Center.X - Radius / 20 * Math.Cos(needleAngle));
                                points[1].Y = (Single)(Center.Y - Radius / 20 * Math.Sin(needleAngle));
                                points[2].X = (Single)(Center.X - Radius / 5 * Math.Cos(needleAngle) + Width * 2 * Math.Cos(needleAngle + Math.PI / 2));
                                points[2].Y = (Single)(Center.Y - Radius / 5 * Math.Sin(needleAngle) + Width * 2 * Math.Sin(needleAngle + Math.PI / 2));
                                Graphics.FillPolygon(brush1, points);

                                points[2].X = (Single)(Center.X - Radius / 5 * Math.Cos(needleAngle) + Width * 2 * Math.Cos(needleAngle - Math.PI / 2));
                                points[2].Y = (Single)(Center.Y - Radius / 5 * Math.Sin(needleAngle) + Width * 2 * Math.Sin(needleAngle - Math.PI / 2));
                                Graphics.FillPolygon(brush2, points);
                            }
                        }

                        if (Math.Floor((Single)(((brushAngle + 135) % 360) / 180.0)) == 0) {
                            using (var brush3 = new SolidBrush(Color.FromArgb(80 + subcol2, 80 + subcol2, 80 + subcol2))) {
                                points[0].X = (Single)(Center.X - (Radius / 20 - 1) * Math.Cos(needleAngle));
                                points[0].Y = (Single)(Center.Y - (Radius / 20 - 1) * Math.Sin(needleAngle));
                                points[1].X = (Single)(Center.X - Radius / 5 * Math.Cos(needleAngle) + Width * 2 * Math.Cos(needleAngle + Math.PI / 2));
                                points[1].Y = (Single)(Center.Y - Radius / 5 * Math.Sin(needleAngle) + Width * 2 * Math.Sin(needleAngle + Math.PI / 2));
                                points[2].X = (Single)(Center.X - Radius / 5 * Math.Cos(needleAngle) + Width * 2 * Math.Cos(needleAngle - Math.PI / 2));
                                points[2].Y = (Single)(Center.Y - Radius / 5 * Math.Sin(needleAngle) + Width * 2 * Math.Sin(needleAngle - Math.PI / 2));
                                Graphics.FillPolygon(brush3, points);
                            }
                        } else {
                            using (var brush3 = new SolidBrush(Color.FromArgb(180 - subcol2, 180 - subcol2, 180 - subcol2))) {
                                points[0].X = (Single)(Center.X - (Radius / 20 - 1) * Math.Cos(needleAngle));
                                points[0].Y = (Single)(Center.Y - (Radius / 20 - 1) * Math.Sin(needleAngle));
                                points[1].X = (Single)(Center.X - Radius / 5 * Math.Cos(needleAngle) + Width * 2 * Math.Cos(needleAngle + Math.PI / 2));
                                points[1].Y = (Single)(Center.Y - Radius / 5 * Math.Sin(needleAngle) + Width * 2 * Math.Sin(needleAngle + Math.PI / 2));
                                points[2].X = (Single)(Center.X - Radius / 5 * Math.Cos(needleAngle) + Width * 2 * Math.Cos(needleAngle - Math.PI / 2));
                                points[2].Y = (Single)(Center.Y - Radius / 5 * Math.Sin(needleAngle) + Width * 2 * Math.Sin(needleAngle - Math.PI / 2));
                                Graphics.FillPolygon(brush3, points);
                            }
                        }

                        points[0].X = (Single)(Center.X - Radius / 20 * Math.Cos(needleAngle));
                        points[0].Y = (Single)(Center.Y - Radius / 20 * Math.Sin(needleAngle));
                        points[1].X = (Single)(Center.X + Radius * Math.Cos(needleAngle));
                        points[1].Y = (Single)(Center.Y + Radius * Math.Sin(needleAngle));

                        Graphics.DrawLine(pen, Center.X, Center.Y, points[0].X, points[0].Y);
                        Graphics.DrawLine(pen, Center.X, Center.Y, points[1].X, points[1].Y);
                    }
                    break;
                case NeedleTypeEnum.Flat:
                    using (var solidBrush = new SolidBrush(ForeColor))
                    using (var pen = new Pen(ForeColor, Width)) {
                        var startPoint = new Point((Int32)(Center.X - Radius / 8 * Math.Cos(needleAngle)), (Int32)(Center.Y - Radius / 8 * Math.Sin(needleAngle)));
                        var endPoint = new Point((Int32)(Center.X + Radius * Math.Cos(needleAngle)), (Int32)(Center.Y + Radius * Math.Sin(needleAngle)));

                        Graphics.FillEllipse(solidBrush, Center.X - Width * 3, Center.Y - Width * 3, Width * 6, Width * 6);
                        Graphics.DrawLine(pen, Center.X, Center.Y, endPoint.X, endPoint.Y);
                        Graphics.DrawLine(pen, Center.X, Center.Y, startPoint.X, startPoint.Y);
                    }
                    break;
            }
        }
    }
}
