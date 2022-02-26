using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Windows.Input;

namespace AvaloniaKeyPad.ViewModels.Actions
{
    public interface IButtonActionViewModel : IActionViewModel
    {
        public string ButtonText { get; }
        public IObservableCollection<string> PressedButtons { get; }
        public ICommand ListenKeyPress { get; }
    }

    public class ButtonActionViewModel : ViewModelBase, IButtonActionViewModel
    {
        private bool isRecording;

        public string ButtonText => isRecording ? "Stop" : "Record";

        public bool IsRecording
        {
            get => isRecording;
            set => this.RaiseAndSetIfChanged(ref isRecording, value);
        }

        public IObservableCollection<string> PressedButtons { get; } = new ObservableCollectionExtended<string>();

        public ICommand ListenKeyPress { get; }

        public ButtonActionViewModel()
        {
            ListenKeyPress = ReactiveCommand.Create(ListenToKeypress);

            this.WhenAnyValue(d => d.IsRecording)
                .ToProperty(this, nameof(ButtonText));
        }

        public bool CanToggleRecording() => !isRecording;
        public void ToggleRecording()
        {
            IsRecording = !IsRecording;
        }

        private void ListenToKeypress()
        {
            if (isRecording)
            {


            }
        }
    }
}
