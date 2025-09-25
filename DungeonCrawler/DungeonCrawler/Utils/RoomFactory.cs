using DungeonCrawler.Enums;
using DungeonCrawler.Models;
using DungeonCrawler.Services;
using DungeonCrawler.Services.Interfaces;
using DungeonCrawler.Utils.Interfaces;

namespace DungeonCrawler.Utils;

public class RoomFactory : IRoomFactory
{
    private readonly IItemFactory _itemFactory;
    private readonly IMonsterFactory _monsterFactory;
    private readonly IBattleService _battleService;
    private readonly List<RoomEventType> _roomEventTypes = [RoomEventType.Treasure, RoomEventType.Trap, RoomEventType.Empty, RoomEventType.Monster];
    private readonly Dictionary<RoomEventType, int> _weight = new()
    {
        { RoomEventType.Monster, 40 },
        { RoomEventType.Treasure, 30 },
        { RoomEventType.Trap, 20 },
        { RoomEventType.Empty, 10 }
    };

    public RoomFactory(IItemFactory itemFactory, IMonsterFactory monsterFactory, IBattleService battleService)
    {
        _itemFactory = itemFactory;
        _monsterFactory = monsterFactory;
        _battleService = battleService;
    }

    public Room GetRoom(bool isStartRoom)
    {
        var roomType = isStartRoom ?
            RoomEventType.Empty :
            GetRoomEventType();
        switch (roomType)
        {
            case RoomEventType.Treasure:
                return new TreasureRoom(_itemFactory, isStartRoom);
            case RoomEventType.Trap:
                return new TrapRoom(isStartRoom);
            case RoomEventType.Empty:
                return new EmptyRoom(isStartRoom);
            case RoomEventType.Monster:
                return new MonsterRoom(_monsterFactory, _battleService, isStartRoom);
            default:
                throw new Exception();
        }
    }

    public Room GetRoom(RoomSaveModel room)
    {
        switch (room.EventType)
        {
            case RoomEventType.Treasure:
                return new TreasureRoom(_itemFactory, room.WasOpened);
            case RoomEventType.Trap:
                return new TrapRoom(room.WasOpened);
            case RoomEventType.Empty:
                return new EmptyRoom(room.WasOpened);
            case RoomEventType.Monster:
                return new MonsterRoom(_monsterFactory, _battleService, room.WasOpened);
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
