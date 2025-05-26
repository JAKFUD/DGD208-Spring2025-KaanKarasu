public class Game
{
    private bool isRunning = true;

    private List<Pet> pets = new List<Pet>();
    private Menu mainMenu;

    public Game()
    {
        mainMenu = new Menu("Main Menu", new List<string>
{
    "1. Show Creator Info",
    "2. Exit Game",
    "3. Adopt a pet",
    "4. View pets"
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
                case "3":
                    AdoptPet();
                    break;
                case "4":
                    ViewPets();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

        }
    }

private void AdoptPet()
{
    Console.WriteLine("Choose a name for your pet:");
    string name = Console.ReadLine();

    Console.WriteLine("Choose a pet type:");
    Console.WriteLine("0 - Cat");
    Console.WriteLine("1 - Dog");
    Console.WriteLine("2 - Dragon");
    Console.WriteLine("3 - Rabbit");

    if (int.TryParse(Console.ReadLine(), out int typeChoice) &&
        Enum.IsDefined(typeof(PetType), typeChoice))
    {
        PetType type = (PetType)typeChoice;
        Pet newPet = new Pet(name, type);
        pets.Add(newPet);
        Console.WriteLine($"✅ You adopted {name} the {type}!");
    }
    else
    {
        Console.WriteLine("Invalid pet type.");
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

private void ViewPets()
{
    if (pets.Count == 0)
    {
        Console.WriteLine("You haven't adopted any pets yet.");
    }
    else
    {
        Console.WriteLine("Your pets:");
        foreach (var pet in pets)
        {
            pet.DisplayStats();
        }
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

    private void ExitGame()
    {
        Console.WriteLine("Exiting the game...");
        isRunning = false;
    }
}
