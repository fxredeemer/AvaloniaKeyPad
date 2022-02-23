using ReactiveUI;
using System.Collections.Generic;

namespace AvaloniaKeyPad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IMenuViewModel Menu { get; }
        public IEnumerable<IButtonViewModel> Buttons { get; } = new List<ButtonViewModel>() { new(), new() };
        public IButtonViewModel? SelectedButton { get; set; }

        public IButtonViewModel? ButtonDetailView => SelectedButton;

        public MainWindowViewModel(IMenuViewModel menuViewModel)
        {
            Menu = menuViewModel;
        }
    }
}
