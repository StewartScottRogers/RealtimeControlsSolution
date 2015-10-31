using System;
using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal static class RectangleExtentions {
        public static Rectangle Deflate(this Rectangle ClientRectangle, Int32 HeightAndWidth) {
            var reducedRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            reducedRectangle.Inflate(-HeightAndWidth, -HeightAndWidth);
            return reducedRectangle;
        }

        public static Rectangle Deflate(this Rectangle ClientRectangle, Int32 Height, Int32 Width) {
            var reducedRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            reducedRectangle.Inflate(-Height, -Width);
            return reducedRectangle;
        }
    }
}
