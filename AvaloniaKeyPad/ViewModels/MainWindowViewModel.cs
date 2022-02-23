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

        public IMenuViewModel Menu { get; }
        public IEnumerable<IButtonViewModel> Buttons => dataRepository.Buttons.Select(d => new ButtonViewModel(d));
        public IButtonViewModel? SelectedButton
        {
            get => selectedButton;
            set => this.RaiseAndSetIfChanged(ref selectedButton, value);
        }

        public ISelectedButtonViewModel? ButtonDetailView { get; set; }

        public MainWindowViewModel(
            IMenuViewModel menuViewModel,
            IDataRepository dataRepository)
        {
            Menu = menuViewModel;
            this.dataRepository = dataRepository;

            this.WhenAnyValue(d => d.SelectedButton)
                .WhereNotNull()
                .ToProperty(this, nameof(ButtonDetailView));
        }
    }
}
