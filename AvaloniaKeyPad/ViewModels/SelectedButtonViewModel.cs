using AvaloniaKeyPad.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaKeyPad.ViewModels
{
    public enum ActionMode
    {
        TextAction,
        ButtonAction
    }


    public interface ISelectedButtonViewModel
    {
        string Identifier { get; }
        IActionViewModel ActionViewModel { get; }
        IEnumerable<ActionMode> ActionModes { get; }
        ActionMode SelectedActionMode { get; set; }
    }

    public class SelectedButtonViewModel : ViewModelBase, ISelectedButtonViewModel
    {
        private readonly IActionViewModelFactory actionViewModelFactory;

        public IButton Button { get; }
        public string Identifier => Button.Name;

        public IActionViewModel ActionViewModel => actionViewModelFactory.GetTextActionViewModel();

        public IEnumerable<ActionMode> ActionModes => Enum.GetValues<ActionMode>();

        public ActionMode SelectedActionMode { get ; set; } = ActionMode.TextAction;

        public SelectedButtonViewModel(
            IActionViewModelFactory actionViewModelFactory,
            IButton button)
        {
            this.actionViewModelFactory = actionViewModelFactory;
            Button = button;

            this.WhenAnyValue(d => d.SelectedActionMode)
                .ToProperty(this, nameof(ActionViewModel));
        }
    }
}
