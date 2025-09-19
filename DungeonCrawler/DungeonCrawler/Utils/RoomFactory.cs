using DungeonCrawler.Enums;
using DungeonCrawler.Models;
using DungeonCrawler.Services;

namespace DungeonCrawler.Utils;

public class RoomFactory
{
    private readonly ItemFactory _itemFactory;
    private readonly MonsterFactory _monsterFactory;
    private readonly BattleService _battleService;
    private readonly List<RoomEventType> _roomEventTypes = [RoomEventType.Treasure, RoomEventType.Trap, RoomEventType.Empty, RoomEventType.Monster];
    private readonly Dictionary<RoomEventType, int> _weight = new()
    {
        { RoomEventType.Monster, 40 },
        { RoomEventType.Treasure, 30 },
        { RoomEventType.Trap, 20 },
        { RoomEventType.Empty, 10 }
    };

    public RoomFactory(ItemFactory itemFactory, MonsterFactory monsterFactory, BattleService battleService)
    {
        _itemFactory = itemFactory;
        _monsterFactory = monsterFactory;
        _battleService = battleService;
    }

    public Room GetRoom()
    {
        var roomType = GetRoomEventType();
        switch (roomType)
        {
            case RoomEventType.Treasure:
                return new TreasureRoom(_itemFactory);
            case RoomEventType.Trap:
                return new TrapRoom();
            case RoomEventType.Empty:
                return new EmptyRoom();
            case RoomEventType.Monster:
                return new MonsterRoom(_monsterFactory, _battleService);
            default:
                throw new Exception();
        }
    }

    private RoomEventType GetRoomEventType()
    {
        var totalWeight = _weight.Values.Sum();
        var roll = DrawService.GetRandomIndex(totalWeight);
        var currentSum = 0;
        foreach (var roomTypeWeight in _weight)
        {
            currentSum += roomTypeWeight.Value;
            if (roll < currentSum)
            {
                return roomTypeWeight.Key;
            }
        }
        throw new Exception("No room generated");
    }
}
