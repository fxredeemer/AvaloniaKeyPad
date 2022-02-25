using AvaloniaKeyPad.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaKeyPad.ViewModels
{
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
        private ActionMode selectedActionMode;

        public IButton Button { get; }
        public string Identifier => Button.Name;

        public IActionViewModel ActionViewModel => actionViewModelFactory.GetActionViewModel(SelectedActionMode);

        public IEnumerable<ActionMode> ActionModes { get; }

        public ActionMode SelectedActionMode
        {
            get => selectedActionMode;
            set => this.RaiseAndSetIfChanged(ref selectedActionMode, value);
        }

        public SelectedButtonViewModel(
            IActionViewModelFactory actionViewModelFactory,
            IButton button)
        {
            this.actionViewModelFactory = actionViewModelFactory;

            Button = button;
            ActionModes = actionViewModelFactory.GetAvailableActions();
            SelectedActionMode = ActionModes.First();

            this.WhenAnyValue(d => d.SelectedActionMode)
                .ToProperty(this, nameof(ActionViewModel));
        }
    }
}
