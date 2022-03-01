using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using AvaloniaKeyPad.ViewModels.Actions;

namespace AvaloniaKeyPad.Views.Actions
{
    public partial class ButtonActionView : UserControl
    {
        public ButtonActionView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void Border_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataContext is IButtonActionViewModel buttonActionViewModel)
            {
                buttonActionViewModel.ListenTopKeyPress(e.Key);
            }
        }
    }
}
