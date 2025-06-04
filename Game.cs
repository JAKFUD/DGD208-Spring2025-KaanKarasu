using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Game
{
    private static List<Pet> pets = new List<Pet>();
    private bool isRunning = true;
    private Menu mainMenu;

    public Game()
    {
        mainMenu = new Menu("Main Menu", new List<string>
        {
            "1. Show Creator Info",
            "2. Exit Game",
            "3. Adopt a pet",
            "4. View pets",
            "5. Use Item"
        });
    }

    public static void RemovePet(Pet pet)
    {
        pets.Remove(pet);
    }

    public void Start()
    {
        while (isRunning)
        {
            Console.Clear();
            mainMenu.Display();
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine()!;

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
                case "5":
                    UseItemMenu().GetAwaiter().GetResult();
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

    private void AdoptPet()
    {
        Console.WriteLine("Choose a name for your pet:");
        string name = Console.ReadLine()!;

        Console.WriteLine("Choose a pet type:");
        Console.WriteLine("0 - Cat");
        Console.WriteLine("1 - Dog");
        Console.WriteLine("2 - Horse");
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

    private async Task UseItemMenu()
    {
        if (pets.Count == 0)
        {
            Console.WriteLine("You have no pets to use items on. Adopt a pet first.");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine("Select a pet:");

        for (int i = 0; i < pets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pets[i].Name} ({pets[i].Type})");
        }

        if (!int.TryParse(Console.ReadLine(), out int petIndex) || petIndex < 1 || petIndex > pets.Count)
        {
            Console.WriteLine("Invalid pet selection.");
            Console.ReadKey();
            return;
        }

        Pet selectedPet = pets[petIndex - 1];

        var availableItems = ItemDatabase.Items.Where(item => item.IsUsableOn(selectedPet.Type)).ToList();

        if (availableItems.Count == 0)
        {
            Console.WriteLine("No items available for this pet.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Select an item:");

        for (int i = 0; i < availableItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableItems[i].Name} (Restores {availableItems[i].RestoreAmount} points, Duration: {availableItems[i].UseDurationSeconds} seconds)");
        }

        if (!int.TryParse(Console.ReadLine(), out int itemIndex) || itemIndex < 1 || itemIndex > availableItems.Count)
        {
            Console.WriteLine("Invalid item selection.");
            Console.ReadKey();
            return;
        }

        Item selectedItem = availableItems[itemIndex - 1];

        Console.WriteLine($"Using {selectedItem.Name} on {selectedPet.Name}...");
        await selectedItem.UseAsync(selectedPet);
        Console.WriteLine("Item used successfully! Press any key to return to main menu.");
        Console.ReadKey();
    }

    public static class ItemDatabase
    {
        public static List<Item> Items { get; } = new List<Item>
        {
            new Item("Food", PetStat.Hunger, 20, 3),
            new Item("Sleep Potion", PetStat.Sleep, 30, 5),
            new Item("Toy", PetStat.Fun, 15, 2)
        };
    }
}
