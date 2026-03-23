// See https://aka.ms/new-console-template for more information
namespace ExampleProject;

using Retr0GUI.Styles;

public class Program
{
    public static void Main(string[] args)
    {
        ShowMainMenu();
    }
    
    static void ShowMainMenu()
    {
        string[] exampleOptions = new string[]
        {
            "Table",
            "Horizontal Menu",
            "Input Field",
            "Object Edit",
            "Exit"
        };
        
        switch (Retr0GUI.GuiControls.VerticalMenu("Welcome to Retr0GUI! Select example with up/down arrow keys.", exampleOptions, ControlStyle.Default))
        {
            case 0:
                ShowTableExample();
                break;
            case 1:
                ShowHorizontalExample();
                break;
            case 2:
                Retr0GUI.GuiControls.InputField("Example Input Field", "Enter text to test", ControlStyle.Default, false, true);
        
                ShowMainMenu();
                break;
            case 3:
                ShowEditObjectExample();
                break;
            case 4:
                Environment.Exit(0);
                break;
            default:
                return;
        }
    }

    static void ShowTableExample()
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
        
        ShowMainMenu();
    }

    static void ShowEditObjectExample()
    {
        Person p = new Person
        {
            Name = "Alex",
            Age = 18,
            IsStudent = true
        };
        
        p = Retr0GUI.GuiControls.EditObject(p, ControlStyle.Default);

        Console.Clear();
        Console.WriteLine("Result: \n");
        Console.WriteLine(p.ToString());

        Console.ReadKey();
        
        ShowMainMenu();
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
        
        ShowMainMenu();
    }
}
