// See https://aka.ms/new-console-template for more information

using Retr0GUI.Styles;

public class Program
{
    public static void Main(string[] args)
    {
        string[,] exampleData =
        {
            { "ID", "Name", "Score" },
            { "1", "Alex", "95" },
            { "2", "John", "88" },
            { "3", "Ivan", "108" },
            { "4", "Jack", "129" },
            { "5", "Jill", "130" }
        };

        Retr0GUI.GuiControls.DrawTable("Welcome to Retr0GUI! This is example spreadsheet:", exampleData, ControlStyle.Default, TableStyle.WithTopBar);
        
        string val = Retr0GUI.GuiControls.InputField("Test", "Enter text to test", ControlStyle.Default, false, true);
        
        ShowVerticalExample(val);
        
        ShowHorizontalExample();
    }

    static void ShowVerticalExample(string inputFieldOutput)
    {
        int selectedOption = Retr0GUI.GuiControls.VerticalMenu($"Your input was: {inputFieldOutput}.Retr0GUI Vertical Menu Example", ["First option", "Second option", "Third option"], ControlStyle.Default);

        switch (selectedOption)
        {
            case 0:
                Console.WriteLine("You selected first option.");
                break;
            case 1:
                Console.WriteLine("You selected second option.");
                break;
            case 2:
                Console.WriteLine("You selected third option.");
                break;
        }
    }

    static void ShowHorizontalExample()
    {
        bool selectedOptionHorizontal = Retr0GUI.GuiControls.HorizontalSwitch("Retr0GUI Horizontal Switch Example", "Yes", "No", ControlStyle.Default);

        if (selectedOptionHorizontal)
        {
            Console.WriteLine("You said Yes!");
        }
        else
        {
            Console.WriteLine("You said No!");
        }
    }
}
