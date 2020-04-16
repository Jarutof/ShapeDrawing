using ShapeDrawing.Modifiers;
using System.Collections.Generic;
using System.Windows;

namespace ShapeDrawing.Shapes
{
    public class Triangle : ShapeBase, IScalable
    {
        public Triangle(Point A = new Point(), Point B = new Point(), Point C = new Point())
        {
            Points = new List<Point>()
            {
                A,
                B,
                C,
                A,
            };
        }
    }
}
