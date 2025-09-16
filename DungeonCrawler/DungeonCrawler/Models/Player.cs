using DungeonCrawler.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonCrawler.Models;

public class Player : ICharacter
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public List<Item> Inventory { get; private set; } = [];

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

    public void UseItem(Item item)
    {
        if (Inventory.Contains(item))
        {
            Attack += item.AttackBonus;
            Defense += item.DefenseBonus;
            Health += item.Healing;
            Inventory.Remove(item); 
        }
    }

    public void AddItem(Item item) 
    { 
        Inventory.Add(item); 
    }
}
