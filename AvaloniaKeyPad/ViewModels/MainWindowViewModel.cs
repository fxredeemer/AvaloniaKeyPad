using AvaloniaKeyPad.Models;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaKeyPad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataRepository dataRepository;

        public IMenuViewModel Menu { get; }
        public IEnumerable<IButtonViewModel> Buttons => dataRepository.Buttons.Select(d => new ButtonViewModel(d));
        public IButtonViewModel? SelectedButton { get; set; }
        public IButtonViewModel? ButtonDetailView => SelectedButton;

        public MainWindowViewModel(
            IMenuViewModel menuViewModel,
            IDataRepository dataRepository)
        {
            Menu = menuViewModel;
            this.dataRepository = dataRepository;
        }
    }
}
