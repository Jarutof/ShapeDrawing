using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapeDrawing
{
    public class PointsDrawer
    {
        public Canvas Canvas { get; }

        internal void Update(IEnumerable<Point> points)
        {
            Polyline polyline = new Polyline() { Stroke = Brushes.Black };

            polyline.Points = new PointCollection(GetNormalizedPoints(points));

            Canvas.Children.Clear();
            Canvas.Children.Add(polyline);
        }

        private IEnumerable<Point> GetNormalizedPoints(IEnumerable<Point> points)
        {
            List<Point> result = new List<Point>(points.Count());
            Point offset = GetOffset(points);

            double width = GetWidth(points, offset.X);
            double height = GetHeight(points, offset.Y);

            Point position = new Point()
            {
                X = (Canvas.ActualWidth - width) / 2,
                Y = (Canvas.ActualHeight - height) / 2
            };
            foreach (var point in points)
            {
                Point newPont = new Point();
                newPont.X = point.X - offset.X + position.X;
                newPont.Y = point.Y - offset.Y + position.Y;

                result.Add(newPont);
            }
            return result;
        }

        private double GetHeight(IEnumerable<Point> points, double y) => points.Max(p => p.Y) - y;
        private double GetWidth(IEnumerable<Point> points, double x) => points.Max(p => p.X) - x;
        private Point GetOffset(IEnumerable<Point> points) => new Point(points.Min(p => p.X), points.Min(p => p.Y));

        public PointsDrawer(Canvas canvas)
        {
            Canvas = canvas;
        }
    }
}
