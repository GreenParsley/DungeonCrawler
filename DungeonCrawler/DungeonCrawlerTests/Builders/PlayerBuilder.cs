using DungeonCrawler.Models;

namespace DungeonCrawlerTests.Builders;

public class PlayerBuilder
{
    private string _name = null!;
    private int _health;
    private int _attack;
    private int _defense;
    private List<Item> _inventory = [];
    private int _xPlayerPosition;
    private int _yPlayerPosition;

    public Player Build()
    {
        var player = new Player(_name, _health, _attack, _defense);
        player.Inventory.AddRange(_inventory);
        player.XPlayerPosition = _xPlayerPosition;
        player.YPlayerPosition = _yPlayerPosition;
        return player;
    }

    public PlayerBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public PlayerBuilder SetHealth(int health)
    {
        _health = health;
        return this;
    }

    public PlayerBuilder SetAttack(int attack)
    {
        _attack = attack;
        return this;
    }

    public PlayerBuilder SetDefense(int defense)
    {
        _defense = defense;
        return this;
    }

    public PlayerBuilder SetInventory(List<Item> items)
    {
        _inventory = items;
        return this;
    }

    public PlayerBuilder SetXPlayerPosition(int x)
    {
        _xPlayerPosition = x;
        return this;
    }

    public PlayerBuilder SetYPlayerPosition(int y)
    {
        _yPlayerPosition = y;
        return this;
    }
}
