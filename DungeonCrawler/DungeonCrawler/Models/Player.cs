using DungeonCrawler.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonCrawler.Models;

public class Player : ICharacter
{
    public string Name { get; private set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
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

    public void AddItem(Item item) 
    { 
        Inventory.Add(item); 
    }

    public void UseItem()
    {
        Console.WriteLine("Do you want to open your inventory? y/n");
        var isOpen = Console.ReadLine();
        if (isOpen != "y")
        {
            return;
        }

        Console.WriteLine("Which item do you want to use? Select a number.");
        for (int i = 0; i < Inventory.Count; i++)
        {
            Console.WriteLine($"{i} - {Inventory[i].Name}");
        }

        Console.WriteLine("Q - quit");
        var action = Console.ReadLine();
        if (action == "Q")
        {
            return;
        }

        var item = Inventory[int.Parse(action)];
        item.Use(this);
        Inventory.Remove(item);
    }
}
