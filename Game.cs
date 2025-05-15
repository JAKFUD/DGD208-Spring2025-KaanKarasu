public class Game
{
    private bool isRunning = true;
    private Menu mainMenu;

    public Game()
    {
        mainMenu = new Menu("Main Menu", new List<string>
        {
            "1. Show Creator Info",
            "2. Exit Game"
        });
    }

    public void Start()
    {
        while (isRunning)
        {
            Console.Clear();
            mainMenu.Display();
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreatorInfo.Show();
                    break;
                case "2":
                    ExitGame();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ExitGame()
    {
        Console.WriteLine("Exiting the game...");
        isRunning = false;
    }
}
