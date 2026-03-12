using Retr0GUI.Styles;

namespace Retr0GUI;

public static class GuiControls
{
    /// <summary>
    /// Shows "dialog" in the console that has multiple options to choose from and control with up and down arrows
    /// </summary>
    /// <param name="title">Title to display on top of the dialog</param>
    /// <param name="options">Options to choose from</param>
    /// <param name="style">Style of the control</param>
    /// <returns>The chosen option's index</returns>
    public static int VerticalMenu(
        string title,
        string[] options,
        ControlStyle style)
    {
        int selectedIndex = 0;
        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            Console.Clear();
            Console.ForegroundColor = style.TitleColor;
            Console.WriteLine(title);
            if (style.UnderlineTitle)
                Console.WriteLine(new string('=', title.Length));
            Console.WriteLine();
            Console.ResetColor();

            for (int i = 0; i < options.Length; i++)
            {
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
    /// <param name="title">Title to display on top of the dialog</param>
    /// <param name="firstOption">First option</param>
    /// <param name="secondOption">Second option</param>
    /// <param name="style">Style of the control</param>
    /// <returns>True or false depending on the chosen option</returns>
    public static bool HorizontalSwitch(
        string title,
        string firstOption,
        string secondOption,
        ControlStyle style)
    {
        int selected = 0;
        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            Console.Clear();
            Console.ForegroundColor = style.TitleColor;
            Console.WriteLine(title);
            if (style.UnderlineTitle)
                Console.WriteLine(new string('=', title.Length));
            Console.WriteLine();
            Console.ResetColor();

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
                    Console.Write($" {(selected == 1 ? secondOption : firstOption)} ");
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

    /// <summary>
    /// Creates input text field, where user can type text
    /// </summary>
    /// <param name="title">Title to display on top of the dialog</param>
    /// <param name="description">Text that is next to the input field</param>
    /// <param name="style">Style of the control</param>
    /// <param name="isPassword">When this is enabled, the input field displays '*' instead of the original text</param>
    /// <param name="required">If the value cannot be empty</param>
    /// <param name="backgroundField">If there should be background behind the user's input.</param>
    /// <returns>The value of the input field</returns>
    public static string InputField(
        string title,
        string description,
        ControlStyle style,
        bool isPassword = false,
        bool required = false,
        bool backgroundField = false)
    {
        string value = "";
        int cursor = 0;
        string error = "";
        ConsoleKeyInfo key;

        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = style.TitleColor;
            Console.WriteLine(title);
            if (style.UnderlineTitle)
                Console.WriteLine(new string('=', title.Length));
            Console.WriteLine();
            Console.ResetColor();

            Console.Write(description + ": ");

            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            for (int i = 0; i <= value.Length; i++)
            {
                bool isCursor = i == cursor;
                char ch = i < value.Length
                    ? (isPassword ? '*' : value[i])
                    : ' ';

                if (isCursor)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    if (backgroundField)
                        Console.BackgroundColor = ConsoleColor.White;
                    else
                        Console.ResetColor();

                    if (backgroundField)
                        Console.ForegroundColor = ConsoleColor.Black;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write(ch);
            }

            Console.ResetColor();

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }

            Console.SetCursorPosition(left + cursor, top);

            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                if (required && value.Length == 0)
                {
                    error = "This field is required.";
                }
                else
                {
                    break;
                }
            }
            else
            {
                error = "";
            }

            if (key.Key == ConsoleKey.LeftArrow && cursor > 0)
                cursor--;
            else if (key.Key == ConsoleKey.RightArrow && cursor < value.Length)
                cursor++;
            else if (key.Key == ConsoleKey.Backspace && cursor > 0)
            {
                value = value.Remove(cursor - 1, 1);
                cursor--;
            }
            else if (!char.IsControl(key.KeyChar))
            {
                value = value.Insert(cursor, key.KeyChar.ToString());
                cursor++;
            }
        }

        Console.CursorVisible = true;
        return value;
    }

    /// <summary>
    /// Draws table spreadsheet in the console and waits for user's input so it can close the table.
    /// </summary>
    /// <param name="title">Title to display on top of the dialog</param>
    /// <param name="data">Data in rows and columns</param>
    /// <param name="style">Style of the control</param>
    /// <param name="tableStyle">Style to use on the table</param>
    public static void DrawTable(
        string title,
        string[,] data,
        ControlStyle style,
        TableStyle tableStyle = TableStyle.None)
    {
        Console.Clear();

        Console.ForegroundColor = style.TitleColor;
        Console.WriteLine(title);
        if (style.UnderlineTitle)
            Console.WriteLine(new string('=', title.Length));
        Console.WriteLine();
        Console.ResetColor();

        int rows = data.GetLength(0);
        int cols = data.GetLength(1);

        int[] colWidths = new int[cols];

        for (int c = 0; c < cols; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                if (data[r, c].Length > colWidths[c])
                    colWidths[c] = data[r, c].Length;
            }
        }

        void DrawSeparator()
        {
            Console.Write("+");
            for (int c = 0; c < cols; c++)
            {
                Console.Write(new string('-', colWidths[c] + 2));
                Console.Write("+");
            }

            Console.WriteLine();
        }

        DrawSeparator();

        for (int r = 0; r < rows; r++)
        {
            Console.Write("|");
            for (int c = 0; c < cols; c++)
            {
                if (tableStyle == TableStyle.WithTopBar && r == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (tableStyle == TableStyle.Alternating && r % 2 == 0)
                {
                    Console.BackgroundColor = r == 0 ? ConsoleColor.White : ConsoleColor.DarkGray;
                    Console.ForegroundColor = r == 0 ? ConsoleColor.Black :  ConsoleColor.White;
                }

                if (c != cols - 1)
                    Console.Write(" " + data[r, c].PadRight(colWidths[c]) + " |");
                else
                    Console.Write(" " + data[r, c].PadRight(colWidths[c]) + " ");

                Console.ResetColor();
                
                if (c == cols - 1)
                    Console.Write('|');
            }

            Console.WriteLine();
            DrawSeparator();
        }

        Console.WriteLine("\nPress any key to close the table...");
        Console.ReadKey();
    }
}