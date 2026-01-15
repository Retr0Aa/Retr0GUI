namespace Retr0GUI;

// obsolete
internal class GUIManager
{
    /// <summary>
    /// Shows "dialog" in the console that has multiple options to choose from and control with up and down arrows
    /// </summary>
    /// <param name="options">Options to choose from</param>
    /// <returns>The chosen option's index</returns>
    public static int VerticalMenu(string[] options)
    {
        int startLeft = Console.CursorLeft;
        int startTop = Console.CursorTop;

        int selectedIndex = 0;
        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(startLeft, startTop + i);
                //Console.Write(new string(' ', Console.WindowWidth - startLeft));
                Console.SetCursorPosition(startLeft, startTop + i);
                
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{options[i]}");
                }
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
                selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;

            if (key == ConsoleKey.DownArrow)
                selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
        } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;
        return selectedIndex;
    }

    /// <summary>
    /// Creates horizontal "switch" to choose from.
    /// </summary>
    /// <param name="firstOption">First option</param>
    /// <param name="secondOption">Second option</param>
    /// <returns>True or false depending on the chosen option</returns>
    public static bool HorizontalSwitch(string firstOption, string secondOption)
    {
        var lastCursorPos = Console.GetCursorPosition();
        
        int selected = 0;
        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            Console.SetCursorPosition(lastCursorPos.Left, lastCursorPos.Top);

            for (int i = 0; i < 2; i++)
            {
                if (i == selected)
                {
                    if (i == 0)
                        Console.BackgroundColor = ConsoleColor.Red;
                    else if (i == 1)
                        Console.BackgroundColor = ConsoleColor.Green;
                    else
                        Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($" {(i == 0 ? secondOption : firstOption)} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($" {(selected == 1 ? secondOption : firstOption) } ");
                }
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.LeftArrow)
                selected = selected == 0 ? 1 : 0;

            if (key == ConsoleKey.RightArrow)
                selected = selected == 1 ? 0 : 1;
        } while (key != ConsoleKey.Enter);
        
        Console.WriteLine();

        Console.CursorVisible = true;
        return selected == 1;
    }
}