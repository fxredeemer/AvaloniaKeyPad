using AvaloniaKeyPad.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaKeyPad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IButtonViewModelFactory buttonViewModelFactory;
        private readonly IDataRepository dataRepository;
        private IButtonViewModel? selectedButton;

        public IEnumerable<IButtonViewModel> Buttons => dataRepository.Buttons.Select(d => buttonViewModelFactory.GetButtonViewModel(d));
        public IMenuViewModel Menu { get; }
        public IStatusBarViewModel StatusBar { get; }

        public IButtonViewModel? SelectedButton
        {
            get => selectedButton;
            set => this.RaiseAndSetIfChanged(ref selectedButton, value);
        }

        public ISelectedButtonViewModel? ButtonDetailView => buttonViewModelFactory.GetSelectedButtonViewModel(selectedButton?.Button);

        public MainWindowViewModel(
            IMenuViewModel menuViewModel,
            IStatusBarViewModel statusBarViewModel,
            IButtonViewModelFactory buttonViewModelFactory,
            IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
            this.buttonViewModelFactory = buttonViewModelFactory;

            Menu = menuViewModel;
            StatusBar = statusBarViewModel;

            this.WhenAnyValue(d => d.SelectedButton)
                .ToProperty(this, nameof(ButtonDetailView));
        }
    }
}
