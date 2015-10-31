using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary {
    internal static class VerticalGridLineRenderer {
        public static void RenderVerticalGridLines(
                                                        this Graphics Graphics, Rectangle ClientRectangle,
                                                        Boolean MinorEnabled, Point MinorStart, Single MinorLength, Single MinorLineLength, Single MinorLineWidth, Color MinorLineForeColor, Int32 MinorNumOfTicks,
                                                        Boolean IntermediateEnabled, Point IntermediateStart, Single IntermediateLength, Single IntermediateLineLength, Single IntermediateTickWidth, Color IntermediateLineForeColor,
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
                for (var index = (Single)(MinorStart.Y + MinorLength - adjustedMinorStepValue); index >= MinorStart.Y; index -= adjustedMinorStepValue) {
                    using (var pen = new Pen(MinorLineForeColor, MinorLineWidth)) {
                        Graphics.DrawLine(pen, new PointF((Single)MinorStart.X, (Single)index + adjustedMinorStepValue), new PointF((Single)MinorStart.X + MinorLineLength, (Single)(index + adjustedMinorStepValue)));
                    }
                }

            if (IntermediateEnabled)
                for (var index = (Single)(IntermediateStart.Y + IntermediateLength - adjustedIntermediateStepValue); index >= IntermediateStart.Y; index -= adjustedMajorStepValue) {
                    using (var pen = new Pen(IntermediateLineForeColor, IntermediateTickWidth)) {
                        Graphics.DrawLine(pen, new PointF((Single)IntermediateStart.X, (Single)index), new PointF((Single)IntermediateStart.X + IntermediateLineLength, (Single)index));
                    }
                }

            if (MajorEnabled)
                for (var index = (Single)(MajorStart.Y + MajorLength); index >= MajorStart.Y - 1; index -= adjustedMajorStepValue) {
                    using (var pen = new Pen(MajorLineForeColor, MajorLineWidth)) {
                        Graphics.DrawLine(pen, new PointF((Single)MajorStart.X, (Single)index), new PointF((Single)MajorStart.X + MajorLineLength, (Single)index));
                    }
                }
        }
    }
}
