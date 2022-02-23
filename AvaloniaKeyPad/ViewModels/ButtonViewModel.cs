using ReactiveUI;

namespace AvaloniaKeyPad.ViewModels
{
    public interface IButtonViewModel
    {
        string Property { get; set; }
    }

    public class ButtonViewModel : ViewModelBase, IButtonViewModel
    {
        public string Property { get; set; } = "Button";
    }
}
