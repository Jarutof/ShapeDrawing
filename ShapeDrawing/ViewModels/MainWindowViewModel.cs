using ShapeDrawing.Commands;
using ShapeDrawing.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShapeDrawing.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ShapeBase _selectedShape;

        public Canvas Canvas { get; } = new Canvas();
        public IList<ShapeBase> Shapes { get; set; }
        public PointsDrawer Drawer { get; }

        private ICommand _scaleIncCmd = null;
        private ICommand _scaleDecCmd = null;
        public ICommand ScaleIncCmd => _scaleIncCmd ?? (_scaleIncCmd = new CommandScale(1.2));
        public ICommand ScaleDecCmd => _scaleDecCmd ?? (_scaleDecCmd = new CommandScale(0.8));


        public ShapeBase SelectedShape
        {
            get => _selectedShape;
            set
            {
                if (_selectedShape == value) return;
                if (_selectedShape != null)
                {
                    _selectedShape.PropertyChanged -= SelectedShape_PropertyChanged;
                }
                _selectedShape = value;
                _selectedShape.PropertyChanged += SelectedShape_PropertyChanged;

                Drawer.Update(_selectedShape.Points);
                OnCanvasChanged();
            }
        }

        private void SelectedShape_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Drawer.Update(_selectedShape.Points);
        }

        private void OnCanvasChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Canvas)));
        }
        public MainWindowViewModel()
        {
            Drawer = new PointsDrawer(Canvas);
            Shapes = new ObservableCollection<ShapeBase>()
            {
                new Rectangle(20, 30) { Name = "Small rectangle" },
                new Rectangle(200, 300) { Name = "Big rectangle" },
                new Triangle(new Point(50,60), new Point(200, 70), new Point(150, 140)) { Name = "Triangle" },
                new EquilateralTriangle(100) { Name = "Equilateral triangle" },
                new Pentagram(100) { Name = "Pentagram" },
                new Pentagon(100) { Name = "Pentagon" }
            };

        }
    }
}
