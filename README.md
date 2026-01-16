# Retr0GUI ![NuGet Version](https://img.shields.io/nuget/v/Retr0A.Retr0GUI)

Retr0GUI is simple console-based C# library.

## Example
![ExampleGif](/assets/example.gif)

This example code can be found in [the example project](/ExampleProject/Program.cs).

## API Reference

- `GUIControls.cs` - This class contains all basic controls

### Methods

```cs
// This method creates vertical menu that can be navigated with left and right arrows
public static int VerticalMenu(string title, string[] options, bool underlineTitle, ConsoleColor titleColor)
```

```cs
// This method creates horizontal toggle switch that can be navigated with up and down arrows
public static bool HorizontalSwitch(string title, string firstOption, string secondOption, bool underlineTitle, ConsoleColor titleColor)
```

```cs
// This method creates text field that can be typed on
public static string InputField(string title, string description, bool isPassword = false, bool required = false, bool underlineTitle = true, ConsoleColor titleColor = ConsoleColor.White)
```
