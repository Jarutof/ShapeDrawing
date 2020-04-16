using System;
using System.Collections.Generic;
using System.Windows;

namespace ShapeDrawing.Shapes
{
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(double size)
        {
            double angle = 60 * Math.PI / 180;
            Points = new List<Point>()
            {
                new Point(0, 0),
                new Point(size * Math.Cos(angle), size * Math.Sin(angle)),
                new Point(size, 0),
                new Point(0, 0),
            };
        }
    }
}
