using DungeonCrawler.Models;

namespace DungeonCrawler.Services;

public class GameService
{
    private readonly int _xExitPosition;
    private readonly int _yExitPosition;

    public GameService()
    {
        _xExitPosition = GameSettings.MaxMazeWidth - 1;
        _yExitPosition = GameSettings.MaxMazeHeight - 1;
    }

    public bool IsOnExit(Player player)
    {
        if (_xExitPosition == player.XPlayerPosition && _yExitPosition == player.YPlayerPosition) 
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
