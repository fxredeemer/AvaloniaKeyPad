using AvaloniaKeyPad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaKeyPad.ViewModels
{
    public interface ISelectedButtonViewModel
    {
        IButton Button { get; }
    }

    public class SelectedButtonViewModel : ViewModelBase, ISelectedButtonViewModel
    {
        public IButton Button { get; }

        public SelectedButtonViewModel(IButton button)
        {
            Button = button;
        }
    }
}
