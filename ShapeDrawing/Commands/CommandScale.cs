using ShapeDrawing.Modifiers;

namespace ShapeDrawing.Commands
{
    public class CommandScale : CommandBase
    {
        private readonly double _volume;
        public CommandScale(double volume) => _volume = volume;
        public override bool CanExecute(object parameter) => (parameter as IScalable) != null;
        public override void Execute(object parameter) => (parameter as IScalable).Scale(_volume);
    }
}
