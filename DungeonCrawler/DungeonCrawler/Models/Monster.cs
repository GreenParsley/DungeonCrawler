using DungeonCrawler.Interfaces;

namespace DungeonCrawler.Models;

public class Monster : ICharacter
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public Monster(string name, int health, int attack, int defense)
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
