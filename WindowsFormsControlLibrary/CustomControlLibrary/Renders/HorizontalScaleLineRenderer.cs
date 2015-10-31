using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class HorizontalScaleLineRenderer {
        public static void RenderHorizontalScaleLines(
                                                        this Graphics Graphics, Rectangle ClientRectangle,
                                                        Boolean MinorEnabled, Point MinorStart, Single MinorLength, Single MinorTickLength, Single MinorTickWidth, Color MinorTickForeColor, Int32 MinorNumOfTicks,
                                                        Boolean IntermediateEnabled, Point IntermediateStart, Single IntermediateLength, Single IntermediateTickLength, Single IntermediateTickWidth, Color IntermediateTickForeColor,
                                                        Boolean MajorEnabled, Point MajorStart, Single MajorLength, Single MajorTickLength, Single MajorTickWidth, Color MajorTickForeColor, Single MajorStepValue,
                                                        Single MinimumValue, Single MaximumValue,
                                                        LinearHorizontalOriantationTypeEnum Oriantation
            ) {
            using (var graphicsPath = new GraphicsPath()) {
                var adjustedMajorStepValue = (Single)MajorStepValue * (MajorLength / (MaximumValue - MinimumValue));
                var adjustedIntermediateStepValue = (Single)adjustedMajorStepValue / 2;
                var adjustedMinorStepValue = (Single)adjustedMajorStepValue / MinorNumOfTicks;

                Graphics.SetClip(ClientRectangle);
                Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                switch (Oriantation) {
                    case LinearHorizontalOriantationTypeEnum.Bottom: {
                            if (MinorEnabled)
                                for (var index = (Single)MinorStart.X; index <= MinorStart.X + MinorLength - adjustedMinorStepValue; index += adjustedMinorStepValue) {
                                    using (var pen = new Pen(MinorTickForeColor, MinorTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)(index + adjustedMinorStepValue), (Single)MinorStart.Y), new PointF((Single)(index + adjustedMinorStepValue), (Single)MinorStart.Y + MinorTickLength));
                                    }
                                }

                            if (IntermediateEnabled)
                                for (var index = (Single)IntermediateStart.X; index <= IntermediateStart.X + IntermediateLength - adjustedIntermediateStepValue; index += adjustedMajorStepValue) {
                                    using (var pen = new Pen(IntermediateTickForeColor, IntermediateTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)(index + adjustedIntermediateStepValue), (Single)IntermediateStart.Y), new PointF((Single)(index + adjustedIntermediateStepValue), (Single)IntermediateStart.Y + IntermediateTickLength));
                                    }
                                }

                            if (MajorEnabled)
                                for (var index = (Single)MajorStart.X; index <= MajorStart.X + MajorLength + 1; index += adjustedMajorStepValue) {
                                    using (var pen = new Pen(MajorTickForeColor, MajorTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)index, (Single)MajorStart.Y), new PointF((Single)index, (Single)MajorStart.Y + MajorTickLength));
                                    }
                                }
                            break;
                        }
                    case LinearHorizontalOriantationTypeEnum.Top: {
                            if (MinorEnabled)
                                for (var index = (Single)MinorStart.X; index <= MinorStart.X + MinorLength - adjustedMinorStepValue; index += adjustedMinorStepValue) {
                                    using (var pen = new Pen(MinorTickForeColor, MinorTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)(index + adjustedMinorStepValue), (Single)MinorStart.Y), new PointF((Single)(index + adjustedMinorStepValue), (Single)MinorStart.Y - MinorTickLength));
                                    }
                                }

                            if (IntermediateEnabled)
                                for (var index = (Single)IntermediateStart.X; index <= IntermediateStart.X + IntermediateLength - adjustedIntermediateStepValue; index += adjustedMajorStepValue) {
                                    using (var pen = new Pen(IntermediateTickForeColor, IntermediateTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)(index + adjustedIntermediateStepValue), (Single)IntermediateStart.Y), new PointF((Single)(index + adjustedIntermediateStepValue), (Single)IntermediateStart.Y - IntermediateTickLength));
                                    }
                                }

                            if (MajorEnabled)
                                for (var index = (Single)MajorStart.X; index <= MajorStart.X + MajorLength + 1; index += adjustedMajorStepValue) {
                                    using (var pen = new Pen(MajorTickForeColor, MajorTickWidth)) {
                                        Graphics.DrawLine(pen, new PointF((Single)index, (Single)MajorStart.Y), new PointF((Single)index, (Single)MajorStart.Y - MajorTickLength));
                                    }
                                }
                            break;
                        }
                }
            }
        }
    }
}