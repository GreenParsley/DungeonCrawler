using DungeonCrawler.Models;

namespace DungeonCrawler.Services;

public class GameService
{
    private readonly int _xExitPosition;
    private readonly int _yExitPosition;
    private readonly MovementService _movementService;

    public GameService(DungeonMapService dungeonMapService, MovementService movementService)
    {
        _xExitPosition = dungeonMapService.Width - 1;
        _yExitPosition = dungeonMapService.Height - 1;
        _movementService = movementService;
    }

    public bool IsOnExit()
    {
        if (_xExitPosition == _movementService.XPlayerPosition && _yExitPosition == _movementService.YPlayerPosition) 
        {
            Console.WriteLine("You left the dungeon!");
            return true;
        }
        else
        { 
            return false; 
        }
    }

    public bool IsDead(Player player)
    {
        if (player.Health <= 0)
        {
            Console.WriteLine("You are dead.");
            return true;
        }
        else
        {
            return false;
        }
    }
}
