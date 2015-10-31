using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary {
    internal static class BackgroundImageRenderer {
        public static void RenderBackgroundImage(this Graphics Graphics, Rectangle ClientRectangle, Color BackColor, Int32 Width, Int32 Height, ImageLayout ImageLayout, Image BackgroundImage) {
            Graphics.SetClip(ClientRectangle);
            Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

            if (BackgroundImage != null) {
                switch (ImageLayout) {
                    case ImageLayout.Center:
                        Graphics.DrawImageUnscaled(BackgroundImage, Width / 2 - BackgroundImage.Width / 2, Height / 2 - BackgroundImage.Height / 2);
                        break;
                    case ImageLayout.None:
                        Graphics.DrawImageUnscaled(BackgroundImage, 0, 0);
                        break;
                    case ImageLayout.Stretch:
                        Graphics.DrawImage(BackgroundImage, 0, 0, Width, Height);
                        break;
                    case ImageLayout.Tile:
                        var pixelOffsetX = 0;
                        var pixelOffsetY = 0;
                        while (pixelOffsetX < Width) {
                            pixelOffsetY = 0;
                            while (pixelOffsetY < Height) {
                                Graphics.DrawImageUnscaled(BackgroundImage, pixelOffsetX, pixelOffsetY);
                                pixelOffsetY += BackgroundImage.Height;
                            }
                            pixelOffsetX += BackgroundImage.Width;
                        }
                        break;
                    case ImageLayout.Zoom:
                        if ((Single)(BackgroundImage.Width / Width) < (Single)(BackgroundImage.Height / Height))
                            Graphics.DrawImage(BackgroundImage, 0, 0, Height, Height);
                        else
                            Graphics.DrawImage(BackgroundImage, 0, 0, Width, Width);
                        break;
                }
            }
        }
    }
}
