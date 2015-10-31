using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary {
    internal static class HorizontalGridLineRenderer {
        public static void RenderHorizontalGridLines(
                                                        this Graphics Graphics, Rectangle ClientRectangle,
                                                        Boolean MinorEnabled, Point MinorStart, Single MinorLength, Single MinorLineLength, Single MinorLineWidth, Color MinorLineForeColor, Int32 MinorNumOfTicks,
                                                        Boolean IntermediateEnabled, Point IntermediateStart, Single IntermediateLength, Single IntermediateLineLength, Single IntermediateLineWidth, Color IntermediateLineForeColor,
                                                        Boolean MajorEnabled, Point MajorStart, Single MajorLength, Single MajorLineLength, Single MajorLineWidth, Color MajorLineForeColor, Single MajorStepValue,
                                                        Single MinimumValue, Single MaximumValue
            ) {
            Graphics.SetClip(ClientRectangle);
            Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var adjustedMajorStepValue = (Single)MajorStepValue * (MajorLength / (MaximumValue - MinimumValue));
            var adjustedIntermediateStepValue = (Single)adjustedMajorStepValue / 2;
            var adjustedMinorStepValue = (Single)adjustedMajorStepValue / MinorNumOfTicks;

            if (MinorEnabled)
                for (var index = (Single)MinorStart.X; index <= MinorStart.X + MinorLength - adjustedMinorStepValue; index += adjustedMinorStepValue) {
                    using (var pen = new Pen(MinorLineForeColor, MinorLineWidth)) {
                        Graphics.DrawLine(pen, new PointF((Single)(index + adjustedMinorStepValue), (Single)MinorStart.Y), new PointF((Single)(index + adjustedMinorStepValue), (Single)MinorStart.Y - MinorLineLength));
                    }
                }

            if (IntermediateEnabled)
                for (var index = (Single)IntermediateStart.X; index <= IntermediateStart.X + IntermediateLength - adjustedIntermediateStepValue; index += adjustedMajorStepValue) {
                    using (var pen = new Pen(IntermediateLineForeColor, IntermediateLineWidth)) {
                        Graphics.DrawLine(pen, new PointF((Single)(index + adjustedIntermediateStepValue), (Single)IntermediateStart.Y), new PointF((Single)(index + adjustedIntermediateStepValue), (Single)IntermediateStart.Y - IntermediateLineLength));
                    }
                }

            if (MajorEnabled)
                for (var index = (Single)MajorStart.X; index <= MajorStart.X + MajorLength + 1; index += adjustedMajorStepValue) {
                    using (var pen = new Pen(MajorLineForeColor, MajorLineWidth)) {
                        Graphics.DrawLine(pen, new PointF((Single)index, (Single)MajorStart.Y), new PointF((Single)index, (Single)MajorStart.Y - MajorLineLength));
                    }
                }
        }
    }
}
