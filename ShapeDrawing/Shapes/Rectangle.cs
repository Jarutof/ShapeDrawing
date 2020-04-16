using ShapeDrawing.Modifiers;
using System.Collections.Generic;
using System.Windows;

namespace ShapeDrawing.Shapes
{
    public class Rectangle : ShapeBase, IScalable
    {
        private double _width;
        private double _height;
        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                CalculatePoints();
            }
        }
        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                CalculatePoints();
            }
        }

        private void CalculatePoints()
        {
            Points = new List<Point>()
            {
                new Point(0, 0),
                new Point(Width, 0),
                new Point(Width, Height),
                new Point(0, Height),
                new Point(0, 0),
            };
        }

        public Rectangle(double width, double height)
        {
            //Position = position;
            Width = width;
            Height = height;
        }


    }
}
