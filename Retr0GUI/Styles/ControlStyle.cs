namespace Retr0GUI.Styles;

public struct ControlStyle()
{
    public static readonly ControlStyle Default = new()
    {
        UnderlineTitle = true,
        TitleColor = ConsoleColor.White
    };

    public bool UnderlineTitle { get; set; } = true;
    public ConsoleColor TitleColor { get; set; } = ConsoleColor.White;
}
