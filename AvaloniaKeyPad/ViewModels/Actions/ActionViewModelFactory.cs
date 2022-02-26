using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaKeyPad.ViewModels.Actions
{
    public interface IActionViewModelFactory
    {
        IEnumerable<ActionMode> GetAvailableActions();

        IActionViewModel GetActionViewModel(ActionMode actionMode);
    }

    public class ActionViewModelFactory : IActionViewModelFactory
    {
        readonly IDictionary<ActionMode, Func<IActionViewModel>> typeFactories = new Dictionary<ActionMode, Func<IActionViewModel>>()
        {
            [ActionMode.Text] = () => new TextActionViewModel(),
            [ActionMode.Button] = () => new ButtonActionViewModel(),
            [ActionMode.Emoji] = () => new EmojiActionViewModel()
        };

        public IEnumerable<ActionMode> GetAvailableActions()
        {
            return typeFactories.Select(d => d.Key);
        }

        public IActionViewModel GetActionViewModel(ActionMode actionMode)
        {
            return typeFactories[actionMode]();
        }
    }
}
