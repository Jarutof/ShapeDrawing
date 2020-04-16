using ShapeDrawing.Modifiers;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ShapeDrawing.Shapes
{
    public class Pentagram : ShapeBase, IScalable
    {
        public Pentagram(double size)
        {
            double angle1 = 36 * Math.PI / 180;
            double angle2 = 72 * Math.PI / 180;
            double angle3 = 108 * Math.PI / 180;

            double edge = size * 0.5 * Math.Tan(angle2);

            Points = new List<Point>()
            {
                new Point(0, 0),
                new Point(size * 0.5, edge),
                new Point(size, 0),
                new Point(size * Math.Cos(angle3), size * Math.Sin(angle3)),
                new Point(edge * Math.Cos(angle1), size * Math.Sin(angle3)),
                new Point(0, 0),
            };
        }
    }
}
