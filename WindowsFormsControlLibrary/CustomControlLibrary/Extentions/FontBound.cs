using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal static class FontBound {
        public class BoundDef {
            public BoundDef() {
                Y1 = 0;
                Y2 = 0;
            }
            public Single Y1 { get; set; }
            public Single Y2 { get; set; }
        }
        public static BoundDef Find(Font Font) {
            var fontBound = new BoundDef();
            using (var imageBitmap = new Bitmap(5, 5))
            using (var imageGraphics = Graphics.FromImage(imageBitmap)) {
                var boundingBox = imageGraphics.MeasureString("0123456789", Font, -1, StringFormat.GenericTypographic);

                using (var bitmap = new Bitmap((Int32)(boundingBox.Width), (Int32)(boundingBox.Height)))
                using (var graphics = Graphics.FromImage(bitmap))
                using (var backBrush = new SolidBrush(Color.White))
                using (var foreBrush = new SolidBrush(Color.Black)) {
                    graphics.FillRectangle(backBrush, 0.0F, 0.0F, boundingBox.Width, boundingBox.Height);
                    graphics.DrawString("0123456789", Font, foreBrush, 0.0F, 0.0F, StringFormat.GenericTypographic);

                    var cursor1 = 0;
                    var cursor2 = 0;
                    var boundfound = false;
                    while ((cursor1 < bitmap.Height) && (!boundfound)) {
                        cursor2 = 0;
                        while ((cursor2 < bitmap.Width) && (!boundfound)) {
                            if (bitmap.GetPixel(cursor2, cursor1) != backBrush.Color) {
                                fontBound.Y1 = cursor1;
                                boundfound = true;
                            }
                            cursor2++;
                        }
                        cursor1++;
                    }

                    cursor1 = bitmap.Height - 1;
                    boundfound = false;
                    while ((0 < cursor1) && (!boundfound)) {
                        cursor2 = 0;
                        while ((cursor2 < bitmap.Width) && (!boundfound)) {
                            if (bitmap.GetPixel(cursor2, cursor1) != backBrush.Color) {
                                fontBound.Y2 = cursor1;
                                boundfound = true;
                            }
                            cursor2++;
                        }
                        cursor1--;
                    }
                }

                return fontBound;
            }
        }
    }
}
