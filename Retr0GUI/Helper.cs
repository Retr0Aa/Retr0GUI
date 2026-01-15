namespace Retr0GUI;

internal class Helper
{
    public static string CovertConsoleKeyToString(ConsoleKey key)
    {
        if ((int)key >= 0x30 && (int)key <= 0x39)
        {
            // Number
            return key.ToString().Replace("D", "");
        }

        if ((int)key >= 0x41 && (int)key <= 0x5A)
        {
            // Alphabet
            return key.ToString();
        }

        // Operator
        switch (key)
        {
            case ConsoleKey.Multiply:
                return "*";
            case ConsoleKey.Add:
                return "+";
            case ConsoleKey.Separator:
                return "\\";
            case ConsoleKey.Subtract:
                return "-";
            case ConsoleKey.Decimal:
                return ".";
            case ConsoleKey.Divide:
                return "/";
        }

        return "";
    }
}