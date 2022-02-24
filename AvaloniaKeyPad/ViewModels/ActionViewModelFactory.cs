namespace AvaloniaKeyPad.ViewModels
{
    public interface IActionViewModelFactory
    {
        ITextActionViewModel GetTextActionViewModel();
    }

    public class ActionViewModelFactory : IActionViewModelFactory
    {
        public ITextActionViewModel GetTextActionViewModel()
        {
            return new TextActionViewModel();
        }
    }
}
