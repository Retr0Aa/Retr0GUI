# Retr0GUI ![NuGet Version](https://img.shields.io/nuget/v/Retr0A.Retr0GUI)

Retr0GUI is simple console-based C# library.

## Example
![ExampleGif](/assets/example.gif)

This example code can be found in [the example project](/ExampleProject/Program.cs).

## API Reference

- `GUIControls.cs` - This class contains all basic controls

### Methods

```csharp
// This method creates vertical menu that can be navigated with left and right arrows
public static int VerticalMenu(
        string title,
        string[] options,
        ControlStyle style)
```

```csharp
// This method creates horizontal toggle switch that can be navigated with up and down arrows
public static bool HorizontalSwitch(
        string title,
        string firstOption,
        string secondOption,
        ControlStyle style)
```

```csharp
// This method creates text field that can be typed on
public static string InputField(
        string title,
        string description,
        ControlStyle style,
        bool isPassword = false,
        bool required = false,
        bool backgroundField = false)
```

```csharp
// Draws table spreadsheet in the console and waits for user's input so it can close the table.
public static void DrawTable(
        string title,
        string[,] data,
        ControlStyle style,
        TableStyle tableStyle = TableStyle.None)
```
