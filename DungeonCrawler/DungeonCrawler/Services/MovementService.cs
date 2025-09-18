using DungeonCrawler.Enums;
using DungeonCrawler.Models;

namespace DungeonCrawler.Services;

public class MovementService
{
    public int XPlayerPosition { get; private set; } = 0;
    public int YPlayerPosition { get; private set; } = 0;
    private readonly DungeonMapService _mapService;

    public MovementService(DungeonMapService dungeonMapService)
    {
        _mapService = dungeonMapService;
    }
    
    public void Move(MoveType move, Player player)
    {
        switch (move)
        {
            case MoveType.Left:
                XPlayerPosition -= 1;
                break;
            case MoveType.Right:
                XPlayerPosition += 1;
                break;
            case MoveType.Up:
                YPlayerPosition -= 1;
                break;
            case MoveType.Down:
                YPlayerPosition += 1;
                break;
            default:
                throw new NotImplementedException();
        }

        var room = _mapService.GetRoomAt(XPlayerPosition, YPlayerPosition);
        room.Enter(player);
    }

    public bool CheckMove(MoveType move)
    {
        switch (move)
        {
            case MoveType.Left:
                return (XPlayerPosition - 1) >= 0;
            case MoveType.Right:
                return (XPlayerPosition + 1) < _mapService.Width;
            case MoveType.Up:
                return (YPlayerPosition - 1) >= 0;
            case MoveType.Down:
                return (YPlayerPosition + 1) < _mapService.Height;
            default:
                throw new NotImplementedException();
        }
    }
}