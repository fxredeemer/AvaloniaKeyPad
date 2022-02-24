using AvaloniaKeyPad.Models;

namespace AvaloniaKeyPad.ViewModels
{
    public interface IButtonViewModel
    {
        IButton Button { get; }
    }

    public class ButtonViewModel : ViewModelBase, IButtonViewModel
    {
        public IButton Button { get; }
        public string Name => Button.Name;
        public string Description => Button.Description;

        public ButtonViewModel(IButton button)
        {
            this.Button = button;
        }
    }
}
