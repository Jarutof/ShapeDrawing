using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ShapeDrawing.Shapes
{
    public interface IHavePoints
    {
        IList<Point> Points { get; set; }
    }
    public abstract class ShapeBase : IHavePoints, INotifyPropertyChanged
    {
        private IList<Point> _points;
        public string Name { get; set; }
        public IList<Point> Points
        {
            get => _points;
            set
            {
                _points = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
