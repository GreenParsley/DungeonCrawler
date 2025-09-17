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
        var roomIndex = DrawService.GetRandomIndex(_roomEventTypes.Count);
        return _roomEventTypes[roomIndex];
    }
}
