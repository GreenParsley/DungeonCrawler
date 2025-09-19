namespace DungeonCrawler.Models;

public class Item
{
    public string Name { get; private set; }
    public int AttackBonus { get; private set; }
    public int DefenseBonus { get; private set; }
    public int Healing { get; private set; }

    public Item(string name, int attackBonus, int defenseBonus, int healing)
    {
        Name = name;
        AttackBonus = attackBonus;
        DefenseBonus = defenseBonus;
        Healing = healing;
    }

    public void Use(Player player)
    {
        player.Attack += AttackBonus;
        player.Defense += DefenseBonus;
        player.Health += Healing;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Name: {this.Name},\nAttack bonus: {this.AttackBonus},\nDefense bonus: {this.DefenseBonus},\nHealing: {this.Healing}\n");
    }
}
