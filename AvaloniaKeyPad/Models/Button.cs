namespace AvaloniaKeyPad.Models
{
    public interface IButton
    {
        string Description { get; }
        string Name { get; }
    }

    public class Button : IButton
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public Button(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
