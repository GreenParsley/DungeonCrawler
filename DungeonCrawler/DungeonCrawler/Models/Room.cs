using DungeonCrawler.Services;
using DungeonCrawler.Utils;

namespace DungeonCrawler.Models;

public abstract class Room
{
    public bool WasOpened { get; protected set; }
    public string Symbol { get; protected set; } = "❓";
    public abstract void Enter(Player player);
}

public class EmptyRoom : Room
{
    public override void Enter(Player player)
    {
        if (!WasOpened)
        {
            WasOpened = true;
            Symbol = "🔓";

        }
        Console.WriteLine("The room is empty.");
    }
}

public class TreasureRoom : EmptyRoom
{
    private readonly ItemFactory _itemFactory;

    public TreasureRoom(ItemFactory itemFactory)
    {
        _itemFactory = itemFactory;
    }

    public override void Enter(Player player)
    {
        if (!WasOpened)
        {
            WasOpened = true;
            Symbol = "💰";
            var item = _itemFactory.CreateItem();
            player.Inventory.Add(item);
            Console.WriteLine($"You found the {item.Name}!");
            item.DisplayStats();
        }
        else
        {
            base.Enter(player);
        }
    }
}

public class TrapRoom : EmptyRoom
{
    public override void Enter(Player player)
    {
        if (!WasOpened)
        {

            WasOpened = true;
            Symbol = "⚠️";
            player.TakeDamage(10);
            Console.WriteLine("It is a trap!");
            player.DisplayStats();
        }
        else
        {
            base.Enter(player);
        }
    }
}

public class MonsterRoom : EmptyRoom
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
        if (!WasOpened)
        {
            WasOpened = true;
            Symbol = "💀";
            var monster = _monsterFactory.CreateMonster(player.XPlayerPosition, player.YPlayerPosition);
            Console.WriteLine($"You meet the {monster.Name}!");
            monster.DisplayStats();
            _battleService.Fight(player, monster);
        }
        else
        {
            base.Enter(player);
        }
    }
}

