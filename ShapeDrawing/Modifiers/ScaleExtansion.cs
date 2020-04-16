using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ShapeDrawing.Modifiers
{
    public static class ScaleExtansion
    {
        public static void Scale(this IScalable src, double volume)
        {
            List<Point> points = new List<Point>(src.Points.Count());
            foreach (var point in src.Points)
            {
                points.Add(new Point(point.X * volume, point.Y * volume));
            }
            src.Points = points;
        }
    }
}
