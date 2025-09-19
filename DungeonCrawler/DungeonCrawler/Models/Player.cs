using DungeonCrawler.Interfaces;
using DungeonCrawler.Services;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonCrawler.Models;

public class Player : ICharacter
{
    public string Name { get; private set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public List<Item> Inventory { get; private set; } = [];
    public int XPlayerPosition { get; set; } = 0;
    public int YPlayerPosition { get; set; } = 0;

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
        if (Inventory.Count == 0)
            return;

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
        var action = CommunicationService.GetIndex(Inventory.Count);
        if (!action.HasQuit)
        {
            var item = Inventory[action.Index];
            item.Use(this);
            Inventory.Remove(item);
            DisplayStats();
        }
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Name: {this.Name},\nHealth: {this.Health},\nAttack: {this.Attack},\nDefense: {this.Defense}\n");
    }
}
