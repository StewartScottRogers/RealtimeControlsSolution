using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsControlLibrary {
    public static class ColorExtentions {
        public static Color MakeShaded(this Color Color, byte d) {
            byte red = 0;
            byte green = 0;
            byte blue = 0;

            if (Color.R > d)
                red = (byte)(Color.R - d);
            if (Color.G > d)
                green = (byte)(Color.G - d);
            if (Color.B > d)
                blue = (byte)(Color.B - d);

            return Color.FromArgb(red, green, blue);
        }
        public static Color MakeHilighted(this Color Color, byte d) {
            byte red = 255;
            byte green = 255;
            byte blue = 255;

            if (Color.R + d < 255)
                red = (byte)(Color.R + d);
            if (Color.G + d < 255)
                green = (byte)(Color.G + d);
            if (Color.B + d < 255)
                blue = (byte)(Color.B + d);

            return Color.FromArgb(red, green, blue);
        }
    }
}
