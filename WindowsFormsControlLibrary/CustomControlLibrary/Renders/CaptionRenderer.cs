using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    internal static class CaptionRenderer {
        public static void RenderCaptions(this Graphics Graphics, Rectangle ClientRectangle, Font Font, CaptionDef[] Captions) {
            Graphics.SetClip(ClientRectangle);
            Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;

            for (Int32 index = 0; index < Captions.Length; index++)
                if (!String.IsNullOrWhiteSpace(Captions[index].Text))
                    if (Captions[index].Visible)
                        Graphics.DrawString(Captions[index].Text, Font, new SolidBrush(Captions[index].ForeColor), Captions[index].Position.X, Captions[index].Position.Y, StringFormat.GenericTypographic);
        }
    }
}
