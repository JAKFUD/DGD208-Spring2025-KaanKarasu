public static class ItemDatabase
{
    public static List<Item> Items { get; } = new List<Item>
    {
        new Item("Food", PetStat.Hunger, 20, 3),
        new Item("Sleep Potion", PetStat.Sleep, 30, 5),
        new Item("Toy", PetStat.Fun, 15, 2)
    };
}
