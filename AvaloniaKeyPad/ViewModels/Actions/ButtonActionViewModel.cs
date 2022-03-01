using Avalonia.Input;
using DynamicData.Binding;
using ReactiveUI;

namespace AvaloniaKeyPad.ViewModels.Actions
{
    public interface IButtonActionViewModel : IActionViewModel
    {
        public string ButtonText { get; }
        public IObservableCollection<Key> PressedButtons { get; }
        void ListenTopKeyPress(Key key);
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

        public IObservableCollection<Key> PressedButtons { get; } = new ObservableCollectionExtended<Key>();

        public ButtonActionViewModel()
        {
            this.WhenAnyValue(d => d.IsRecording)
                .ToProperty(this, nameof(ButtonText));
        }

        public bool CanToggleRecording() => !isRecording;
        public void ToggleRecording()
        {
            if (!isRecording)
            {
                PressedButtons.Clear();
            }

            IsRecording = !IsRecording;
        }

        public void ListenTopKeyPress(Key key)
        {
            if (isRecording)
            {
                if (!PressedButtons.Contains(key))
                {
                    PressedButtons.Add(key);
                }
            }
        }
    }
}
