using DynamicData.Binding;

namespace AvaloniaKeyPad.Models
{
    public interface IDataRepository
    {
        IObservableCollection<Button> Buttons { get; }
    }

    public class DataRepository : IDataRepository
    {
        public IObservableCollection<Button> Buttons { get; } = new ObservableCollectionExtended<Button>();

        public DataRepository()
        {
            Buttons.Add(new("1", "fdssdf"));
            Buttons.Add(new("2", "sxcxy"));
            Buttons.Add(new("3", "4were"));
            Buttons.Add(new("4", "gfdhdhgf"));
        }
    }
}
