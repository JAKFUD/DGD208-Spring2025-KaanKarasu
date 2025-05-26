public class Pet
{
    public string name;
    public PetType type;
    public int hunger;
    public int sleep;
    public int fun;

    public Pet(string name, PetType type)
    {
        this.name = name;
        this.type = type;
        hunger = 50;
        sleep = 50;
        fun = 50;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Name: {name} ({type}) | Hunger: {hunger} | Sleep: {sleep} | Fun: {fun}");
    }
}
