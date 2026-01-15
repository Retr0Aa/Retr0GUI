// See https://aka.ms/new-console-template for more information

public class Program
{
    public static void Main(string[] args)
    {
        string val = Retr0GUI.GUIControls.InputField("Test", "Enter text to test", false, true);
        
        ShowVerticalExample();
        
        ShowHorizontalExample();
    }

    static void ShowVerticalExample()
    {
        int selectedOption = Retr0GUI.GUIControls.VerticalMenu("Retr0GUI Vertical Menu Example", ["First option", "Second option", "Third option"]);

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
        bool selectedOptionHorizontal = Retr0GUI.GUIControls.HorizontalSwitch("Retr0GUI Horizontal Switch Example", "Yes", "No");

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
