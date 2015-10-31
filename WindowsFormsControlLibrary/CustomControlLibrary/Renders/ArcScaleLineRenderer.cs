using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary {
    internal static class ArcScaleLineRenderer {
        public static void RenderArcScaleLines(
                                                    this Graphics Graphics, Rectangle ClientRectangle, Point Center,
                                                    Int32 MinorTickOuterRadius, Int32 MinorTickInnerRadius, Int32 MinorTickWidth, Color MinorTickForeColor, Int32 MinorNumOfTicks,
                                                    Int32 IntermediateTickOuterRadius, Int32 IntermediateTickInnerRadius, Int32 IntermediateTickWidth, Color IntermediateTickForeColor,
                                                    Int32 MajorTickOuterRadius, Int32 MajorTickInnerRadius, Int32 MajorTickWidth, Color MajorTickForeColor, Single MajorStepValue,
                                                    Single MinimumValue, Single MaximumValue,
                                                    Int32 ArcStart, Int32 ArcSweep
            ) {
            using (var graphicsPath = new GraphicsPath()) {
                var renderMajorScale = true;
                var renderIntermediateScale = true;
                var renderMinorScale = true;

                Graphics.SetClip(ClientRectangle);
                Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                Single countValue = 0;
                Int32 counter1 = 0;
                while (countValue <= (MaximumValue - MinimumValue)) {

                    graphicsPath.Reset();
                    if (renderMajorScale) {
                        graphicsPath.AddEllipse(new Rectangle(Center.X - MajorTickOuterRadius, Center.Y - MajorTickOuterRadius, 2 * MajorTickOuterRadius, 2 * MajorTickOuterRadius));
                        graphicsPath.Reverse();
                        graphicsPath.AddEllipse(new Rectangle(Center.X - MajorTickInnerRadius, Center.Y - MajorTickInnerRadius, 2 * MajorTickInnerRadius, 2 * MajorTickInnerRadius));
                        graphicsPath.Reverse();
                    }
                    Graphics.SetClip(graphicsPath);

                    using (var pen = new Pen(MajorTickForeColor, MajorTickWidth)) {
                        Graphics.DrawLine(
                                            pen,
                                            (Single)(Center.X),
                                            (Single)(Center.Y),
                                            (Single)(Center.X + 2 * MajorTickOuterRadius * Math.Cos((ArcStart + countValue * ArcSweep / (MaximumValue - MinimumValue)) * Math.PI / 180.0)),
                                            (Single)(Center.Y + 2 * MajorTickOuterRadius * Math.Sin((ArcStart + countValue * ArcSweep / (MaximumValue - MinimumValue)) * Math.PI / 180.0))
                                         );
                    }


                    graphicsPath.Reset();
                    if (renderMinorScale) {                       
                        graphicsPath.AddEllipse(new Rectangle(Center.X - MinorTickOuterRadius, Center.Y - MinorTickOuterRadius, 2 * MinorTickOuterRadius, 2 * MinorTickOuterRadius));
                        graphicsPath.Reverse();
                        graphicsPath.AddEllipse(new Rectangle(Center.X - MinorTickInnerRadius, Center.Y - MinorTickInnerRadius, 2 * MinorTickInnerRadius, 2 * MinorTickInnerRadius));
                        graphicsPath.Reverse();
                    }
                    Graphics.SetClip(graphicsPath);

                    if (countValue < (MaximumValue - MinimumValue)) {
                        for (var index = 1; index <= MinorNumOfTicks; index++) {
                            if (((MinorNumOfTicks % 2) == 1) && ((Int32)(MinorNumOfTicks / 2) + 1 == index)) {

                                graphicsPath.Reset();
                                if (renderIntermediateScale) {
                                    graphicsPath.AddEllipse(new Rectangle(Center.X - IntermediateTickOuterRadius, Center.Y - IntermediateTickOuterRadius, 2 * IntermediateTickOuterRadius, 2 * IntermediateTickOuterRadius));
                                    graphicsPath.Reverse();
                                    graphicsPath.AddEllipse(new Rectangle(Center.X - IntermediateTickInnerRadius, Center.Y - IntermediateTickInnerRadius, 2 * IntermediateTickInnerRadius, 2 * IntermediateTickInnerRadius));
                                    graphicsPath.Reverse();
                                }
                                Graphics.SetClip(graphicsPath);

                                using (var pen = new Pen(IntermediateTickForeColor, IntermediateTickWidth)) {
                                    Graphics.DrawLine(
                                                        pen,
                                                        (Single)(Center.X),
                                                        (Single)(Center.Y),
                                                        (Single)(Center.X + 2 * IntermediateTickOuterRadius * Math.Cos((ArcStart + countValue * ArcSweep / (MaximumValue - MinimumValue) + index * ArcSweep / (((Single)((MaximumValue - MinimumValue) / MajorStepValue)) * (MinorNumOfTicks + 1))) * Math.PI / 180.0)),
                                                        (Single)(Center.Y + 2 * IntermediateTickOuterRadius * Math.Sin((ArcStart + countValue * ArcSweep / (MaximumValue - MinimumValue) + index * ArcSweep / (((Single)((MaximumValue - MinimumValue) / MajorStepValue)) * (MinorNumOfTicks + 1))) * Math.PI / 180.0))
                                                      );
                                }

                                graphicsPath.Reset();
                                if (renderMinorScale) {
                                    graphicsPath.AddEllipse(new Rectangle(Center.X - MinorTickOuterRadius, Center.Y - MinorTickOuterRadius, 2 * MinorTickOuterRadius, 2 * MinorTickOuterRadius));
                                    graphicsPath.Reverse();
                                    graphicsPath.AddEllipse(new Rectangle(Center.X - MinorTickInnerRadius, Center.Y - MinorTickInnerRadius, 2 * MinorTickInnerRadius, 2 * MinorTickInnerRadius));
                                    graphicsPath.Reverse();
                                }
                                Graphics.SetClip(graphicsPath);

                            } else {
                                using (var pen = new Pen(MinorTickForeColor, MinorTickWidth)) {
                                    Graphics.DrawLine(
                                                        pen,
                                                        (Single)(Center.X),
                                                        (Single)(Center.Y),
                                                        (Single)(Center.X + 2 * MinorTickOuterRadius * Math.Cos((ArcStart + countValue * ArcSweep / (MaximumValue - MinimumValue) + index * ArcSweep / (((Single)((MaximumValue - MinimumValue) / MajorStepValue)) * (MinorNumOfTicks + 1))) * Math.PI / 180.0)),
                                                        (Single)(Center.Y + 2 * MinorTickOuterRadius * Math.Sin((ArcStart + countValue * ArcSweep / (MaximumValue - MinimumValue) + index * ArcSweep / (((Single)((MaximumValue - MinimumValue) / MajorStepValue)) * (MinorNumOfTicks + 1))) * Math.PI / 180.0))
                                                     );
                                }
                            }
                        }
                    }

                    countValue += MajorStepValue;
                    counter1++;
                }
            }
            Graphics.ResetTransform();
        }
    }
}
