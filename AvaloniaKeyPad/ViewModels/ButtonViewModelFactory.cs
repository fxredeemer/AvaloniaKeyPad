using AvaloniaKeyPad.Models;

namespace AvaloniaKeyPad.ViewModels
{
    public interface IButtonViewModelFactory
    {
        IButtonViewModel GetButtonViewModel(IButton button);
        ISelectedButtonViewModel? GetSelectedButtonViewModel(IButton? button);
    }

    public class ButtonViewModelFactory : IButtonViewModelFactory
    {
        private readonly IActionViewModelFactory actionViewModelFactory;

        public ButtonViewModelFactory(IActionViewModelFactory actionViewModelFactory)
        {
            this.actionViewModelFactory = actionViewModelFactory;
        }

        public IButtonViewModel GetButtonViewModel(IButton button)
        {
            return new ButtonViewModel(button);
        }

        public ISelectedButtonViewModel? GetSelectedButtonViewModel(IButton? button)
        {
            if (button == null)
            {
                return null;
            }

            return new SelectedButtonViewModel(actionViewModelFactory, button);
        }
    }
}
