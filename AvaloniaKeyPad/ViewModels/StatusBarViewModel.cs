namespace AvaloniaKeyPad.ViewModels
{
    public interface IStatusBarViewModel
    {
        public string Status { get; }
    }

    public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        public string Status { get; } = "Whatya looking at";
    }
}
