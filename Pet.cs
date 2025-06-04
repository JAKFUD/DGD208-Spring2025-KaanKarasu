using System;
using System.Threading.Tasks;

public class Pet
{
    public string Name { get; }
    public PetType Type { get; }

    public int Hunger { get; private set; }
    public int Sleep { get; private set; }
    public int Fun { get; private set; }

    public bool IsDead { get; private set; }

    public Pet(string name, PetType type)
    {
        Name = name;
        Type = type;
        Hunger = 50;
        Sleep = 50;
        Fun = 50;
        IsDead = false;

        StartStatDecay();
    }

    private async void StartStatDecay()
    {
        while (!IsDead)
        {
            await Task.Delay(5000);

            Hunger--;
            Sleep--;
            Fun--;

            if (Hunger <= 0 || Sleep <= 0 || Fun <= 0)
            {
                IsDead = true;
                Console.WriteLine($"⚠️ {Name} the {Type} has died!");
                Game.RemovePet(this);
            }
        }
    }

    public void IncreaseStat(PetStat stat, int amount)
    {
        switch (stat)
        {
            case PetStat.Hunger:
                Hunger = Math.Min(100, Hunger + amount);
                break;
            case PetStat.Sleep:
                Sleep = Math.Min(100, Sleep + amount);
                break;
            case PetStat.Fun:
                Fun = Math.Min(100, Fun + amount);
                break;
        }
    }

    public void DisplayStats()
    {
        Console.Write($"{Name} ({Type}) - Hunger: ");
        ShowStatWithColor(Hunger);

        Console.Write(" | Sleep: ");
        ShowStatWithColor(Sleep);

        Console.Write(" | Fun: ");
        ShowStatWithColor(Fun);

        Console.WriteLine();
        Console.ResetColor();}
    private void ShowStatWithColor(int stat)
{
    if (stat <= 30)
        Console.ForegroundColor = ConsoleColor.Red;
    else if (stat <= 70)
        Console.ForegroundColor = ConsoleColor.Yellow;
    else
        Console.ForegroundColor = ConsoleColor.Green;

    Console.Write(stat);
    Console.ResetColor();
}}

