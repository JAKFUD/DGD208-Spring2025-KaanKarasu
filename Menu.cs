using System;
using System.Collections.Generic;

public class Menu
{
    private string Title;
    private List<string> Options;

    public Menu(string title, List<string> options)
    {
        Title = title;
        Options = options;
    }

    public void Display()
    {
        Console.WriteLine($"=== {Title} ===");
        foreach (var option in Options)
        {
            Console.WriteLine(option);
        }
    }
}
