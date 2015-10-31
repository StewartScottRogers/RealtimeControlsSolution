using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class VerticalScaleLineRenderer {
        public static void RenderVerticalScaleLines(
                                                        this Graphics Graphics, Rectangle ClientRectangle,
                                                        Boolean MinorEnabled, Point MinorStart, Single MinorLength, Single MinorTickLength, Single MinorTickWidth, Color MinorTickForeColor, Int32 MinorNumOfTicks,
                                                        Boolean IntermediateEnabled, Point IntermediateStart, Single IntermediateLength, Single IntermediateTickLength, Single IntermediateTickWidth, Color IntermediateTickForeColor,
                                                        Boolean MajorEnabled, Point MajorStart, Single MajorLength, Single MajorTickLength, Single MajorTickWidth, Color MajorTickForeColor, Single MajorStepValue,
                                                        Single MinimumValue, Single MaximumValue,
                                                        LinearVerticalOriantationTypeEnum Oriantation
            ) {
            using (var graphicsPath = new GraphicsPath()) {
                var adjustedMajorStepValue = (Single)MajorStepValue * (MajorLength / (MaximumValue - MinimumValue));
                var adjustedIntermediateStepValue = (Single)adjustedMajorStepValue / 2;
                var adjustedMinorStepValue = (Single)adjustedMajorStepValue / MinorNumOfTicks;

                Graphics.SetClip(ClientRectangle);
                Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                switch (Oriantation) {
                    case LinearVerticalOriantationTypeEnum.Right: {
                            if (MinorEnabled)
                                for (var index = (Single)(MinorStart.Y + MinorLength - adjustedMinorStepValue); index >= MinorStart.Y; index -= adjustedMinorStepValue) {
                                    using (var pen = new Pen(MinorTickForeColor, MinorTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)MinorStart.X, (Single)index + adjustedMinorStepValue), new PointF((Single)MinorStart.X + MinorTickLength, (Single)(index + adjustedMinorStepValue)));
                                    }
                                }

                            if (IntermediateEnabled)
                                for (var index = (Single)(IntermediateStart.Y + IntermediateLength - adjustedIntermediateStepValue); index >= IntermediateStart.Y; index -= adjustedMajorStepValue) {
                                    using (var pen = new Pen(IntermediateTickForeColor, IntermediateTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)IntermediateStart.X, (Single)index), new PointF((Single)IntermediateStart.X + IntermediateTickLength, (Single)index));
                                    }
                                }

                            if (MajorEnabled)
                                for (var index = (Single)(MajorStart.Y + MajorLength); index >= MajorStart.Y - 1; index -= adjustedMajorStepValue) {
                                    using (var pen = new Pen(MajorTickForeColor, MajorTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)MajorStart.X, (Single)index), new PointF((Single)MajorStart.X + MajorTickLength, (Single)index));
                                    }
                                }
                            break;
                        }
                    case LinearVerticalOriantationTypeEnum.Left: {
                            if (MinorEnabled)
                                for (var index = (Single)(MinorStart.Y + MinorLength - adjustedMinorStepValue); index >= MinorStart.Y; index -= adjustedMinorStepValue) {
                                    using (var pen = new Pen(MinorTickForeColor, MinorTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)MinorStart.X, (Single)index + adjustedMinorStepValue), new PointF((Single)MinorStart.X - MinorTickLength, (Single)(index + adjustedMinorStepValue)));
                                    }
                                }

                            if (IntermediateEnabled)
                                for (var index = (Single)(IntermediateStart.Y + IntermediateLength - adjustedIntermediateStepValue); index >= IntermediateStart.Y; index -= adjustedMajorStepValue) {
                                    using (var pen = new Pen(IntermediateTickForeColor, IntermediateTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)IntermediateStart.X, (Single)index), new PointF((Single)IntermediateStart.X - IntermediateTickLength, (Single)index));
                                    }
                                }

                            if (MajorEnabled)
                                for (var index = (Single)(MajorStart.Y + MajorLength); index >= MajorStart.Y - 1; index -= adjustedMajorStepValue) {
                                    using (var pen = new Pen(MajorTickForeColor, MajorTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)MajorStart.X, (Single)index), new PointF((Single)MajorStart.X - MajorTickLength, (Single)index));
                                    }
                                }
                            break;
                        }
                }
            }
        }
    }
}