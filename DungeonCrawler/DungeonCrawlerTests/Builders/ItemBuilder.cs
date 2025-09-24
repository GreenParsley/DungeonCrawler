using DungeonCrawler.Models;

namespace DungeonCrawlerTests.Builders;

public class ItemBuilder
{
    private string _name = null!;
    private int _attackBonus;
    private int _defenseBonus;
    private int _healing;

    public Item Build()
    {
        return new Item(_name, _attackBonus, _defenseBonus, _healing);
    }

    public ItemBuilder SetName(string name)
    { 
        _name = name; 
        return this; 
    }

    public ItemBuilder SetAttackBonus(int attack)
    {
        _attackBonus = attack;
        return this;
    }

    public ItemBuilder SetDefenseBonus(int defense)
    {
        _defenseBonus = defense;
        return this;
    }

    public ItemBuilder SetHealing(int healing)
    {
        _healing = healing;
        return this;
    }
}
