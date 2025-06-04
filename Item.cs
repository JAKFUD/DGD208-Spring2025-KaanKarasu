using System;
using System.Threading.Tasks;

public class Item
{
    public string Name { get; }
    public PetStat StatToRestore { get; }
    public int RestoreAmount { get; }
    public int UseDurationSeconds { get; }

    public Item(string name, PetStat statToRestore, int restoreAmount, int useDurationSeconds)
    {
        Name = name;
        StatToRestore = statToRestore;
        RestoreAmount = restoreAmount;
        UseDurationSeconds = useDurationSeconds;
    }

    public async Task UseAsync(Pet pet)
    {
        Console.WriteLine($"Using {Name} on {pet.Name}... Please wait {UseDurationSeconds} seconds.");
        await Task.Delay(UseDurationSeconds * 1000);
        pet.IncreaseStat(StatToRestore, RestoreAmount);
        Console.WriteLine($"{pet.Name}'s {StatToRestore} increased by {RestoreAmount}!");
    }

    public bool IsUsableOn(PetType petType)
    {
        
        return true;
    }
}
