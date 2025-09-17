using DungeonCrawler.Services;
using DungeonCrawler.Utils;

namespace DungeonCrawler.Models;

public abstract class Room
{
    public abstract void Enter(Player player);
}

public class EmptyRoom : Room
{
    public override void Enter(Player player)
    {
        Console.WriteLine("The room is empty.");
    }
}

public class TreasureRoom : Room
{
    private readonly ItemFactory _itemFactory;

    public TreasureRoom(ItemFactory itemFactory)
    {
        _itemFactory = itemFactory;
    }

    public override void Enter(Player player)
    {
        var item = _itemFactory.CreateItem();
        player.Inventory.Add(item);
        Console.WriteLine($"You found the {item.Name}!");
    }
}

public class TrapRoom : Room
{
    public override void Enter(Player player)
    {
        player.TakeDamage(10);
        Console.WriteLine("It is a trap!");
    }
}

public class MonsterRoom : Room
{
    private readonly MonsterFactory _monsterFactory;
    private readonly BattleService _battleService;

    public MonsterRoom(MonsterFactory monsterFactory, BattleService battleService)
    {
        _monsterFactory = monsterFactory;
        _battleService = battleService;
    }
    public override void Enter(Player player)
    {
        var monster = _monsterFactory.CreateMonster();
        Console.WriteLine($"You met the {monster.Name}!");
        _battleService.Fight(player, monster);
    }
}

