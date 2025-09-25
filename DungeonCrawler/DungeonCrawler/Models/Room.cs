using DungeonCrawler.Enums;
using DungeonCrawler.Services.Interfaces;
using DungeonCrawler.Utils;
using DungeonCrawler.Utils.Interfaces;

namespace DungeonCrawler.Models;

public abstract class Room
{
    public RoomEventType Type { get; set; }
    public bool WasOpened { get; protected set; }
    public string Symbol { get; protected set; } = "❓";
    public abstract void Enter(Player player);
}

public class EmptyRoom : Room
{
    public EmptyRoom(bool isStartRoom)
    {
        Type = RoomEventType.Empty;
        if (isStartRoom)
        {
            WasOpened = true;
            Symbol = "🔓";
        }    
    }

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
    private readonly IItemFactory _itemFactory;

    public TreasureRoom(IItemFactory itemFactory) : base(false)
    {
        _itemFactory = itemFactory;
        Type = RoomEventType.Treasure;
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
    public TrapRoom() : base(false)
    {
        Type = RoomEventType.Trap;
    }

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
    private readonly IMonsterFactory _monsterFactory;
    private readonly IBattleService _battleService;

    public MonsterRoom(IMonsterFactory monsterFactory, IBattleService battleService) : base(false)
    {
        _monsterFactory = monsterFactory;
        _battleService = battleService;
        Type = RoomEventType.Monster;
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

