using AvaloniaKeyPad.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaKeyPad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataRepository dataRepository;
        private IButtonViewModel? selectedButton;

        public IEnumerable<IButtonViewModel> Buttons => dataRepository.Buttons.Select(d => new ButtonViewModel(d));
        public IMenuViewModel Menu { get; }
        public IStatusBarViewModel StatusBar { get; }

        public IButtonViewModel? SelectedButton
        {
            get => selectedButton;
            set => this.RaiseAndSetIfChanged(ref selectedButton, value);
        }

        public ISelectedButtonViewModel? ButtonDetailView
        {
            get
            {
                if (selectedButton == null)
                {
                    return null;
                }
                return new SelectedButtonViewModel(selectedButton.Button);
            }
        }

        public MainWindowViewModel(
            IMenuViewModel menuViewModel,
            IStatusBarViewModel statusBarViewModel,
            IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
            Menu = menuViewModel;
            StatusBar = statusBarViewModel;

            this.WhenAnyValue(d => d.SelectedButton)
                .ToProperty(this, nameof(ButtonDetailView));
        }
    }
}
