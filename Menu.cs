public class Menu
{
    private string title;
    private List<string> options;

    public Menu(string title, List<string> options)
    {
        this.title = title;
        this.options = options;
    }

    public void Display()
    {
        Console.WriteLine("=== " + title + " ===");
        foreach (var option in options)
        {
            Console.WriteLine(option);
        }
    }
}
