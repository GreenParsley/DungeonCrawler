using DungeonCrawler.Interfaces;

namespace DungeonCrawler.Models;

public class Player : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public List<string> Inventory { get; set; }

    public Player(string name, int health, int attack, int defense)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public bool IsAlive() 
    { 
        if (Health <= 0) 
            return false;
        else 
            return true;
    }
}
