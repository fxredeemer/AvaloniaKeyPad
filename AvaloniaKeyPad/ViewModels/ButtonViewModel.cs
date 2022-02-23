using AvaloniaKeyPad.Models;

namespace AvaloniaKeyPad.ViewModels
{
    public interface IButtonViewModel : IButton { }

    public class ButtonViewModel : ViewModelBase, IButtonViewModel
    {
        private readonly Button button;

        public string Name => button.Name;
        public string Description => button.Description;

        public ButtonViewModel(Button button)
        {
            this.button = button;
        }
    }
}
