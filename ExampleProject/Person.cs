namespace ExampleProject;

/// <summary>
/// This is example class used for object edit example
/// </summary>
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsStudent { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}\n" +
               $"Age: {Age}\n" +
               $"IsStudent: {IsStudent}";
    }
}
