namespace AvaloniaKeyPad.ViewModels
{
    public interface ITextActionViewModel : IActionViewModel
    {
        string? Text { get; set; }
    }

    public class TextActionViewModel : ViewModelBase, ITextActionViewModel
    {
        public string? Text { get; set; }
    }
}
