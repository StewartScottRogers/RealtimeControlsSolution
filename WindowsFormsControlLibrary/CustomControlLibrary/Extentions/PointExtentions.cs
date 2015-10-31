using System.Drawing;

namespace WindowsFormsControlLibrary {
    internal static class PointExtentions {            
        public static bool IsWithin(this Point Point, Rectangle Rectangle) {
            if (Point.X > Rectangle.X && Point.X < Rectangle.X + Rectangle.Width && Point.Y > Rectangle.Y && Point.Y < Rectangle.Y + Rectangle.Height)
                return true;
            return false;
        }   
    }
}
