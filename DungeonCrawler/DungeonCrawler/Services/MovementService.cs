using DungeonCrawler.Enums;
using DungeonCrawler.Models;

namespace DungeonCrawler.Services;

public class MovementService
{
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
                player.XPlayerPosition -= 1;
                break;
            case MoveType.Right:
                player.XPlayerPosition += 1;
                break;
            case MoveType.Up:
                player.YPlayerPosition -= 1;
                break;
            case MoveType.Down:
                player.YPlayerPosition += 1;
                break;
            default:
                throw new NotImplementedException();
        }

        var room = _mapService.GetRoomAt(player.XPlayerPosition, player.YPlayerPosition);
        room.Enter(player);
    }

    public bool CheckMove(MoveType move, Player player)
    {
        switch (move)
        {
            case MoveType.Left:
                return (player.XPlayerPosition - 1) >= 0;
            case MoveType.Right:
                return (player.XPlayerPosition + 1) < GameSettings.MaxMazeWidth;
            case MoveType.Up:
                return (player.YPlayerPosition - 1) >= 0;
            case MoveType.Down:
                return (player.YPlayerPosition + 1) < GameSettings.MaxMazeHeight;
            default:
                throw new NotImplementedException();
        }
    }
}