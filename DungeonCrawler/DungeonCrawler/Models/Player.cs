using DungeonCrawler.Interfaces;
using DungeonCrawler.Services;
using System;
using System.Diagnostics.CodeAnalysis;

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

    public void UseItem(int index)
    {
        if (Inventory.Count == 0)
            return;

        var item = Inventory[index];
        item.Use(this);
        Inventory.Remove(item);
        DisplayStats();
    }

    [ExcludeFromCodeCoverage]
    public void DisplayStats()
    {
        Console.WriteLine($"Name: {this.Name},\nHealth: {this.Health},\nAttack: {this.Attack},\nDefense: {this.Defense}\n");
    }
}
