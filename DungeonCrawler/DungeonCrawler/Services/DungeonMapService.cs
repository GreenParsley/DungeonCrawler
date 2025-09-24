using DungeonCrawler.Models;
using DungeonCrawler.Services.Interfaces;
using DungeonCrawler.Utils.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace DungeonCrawler.Services;

[ExcludeFromCodeCoverage]
public class DungeonMapService : IDungeonMapService
{
    private readonly Room[,] _map;

    public DungeonMapService(IRoomFactory roomFactory)
    {
        _map = new Room[GameSettings.MaxMazeWidth, GameSettings.MaxMazeHeight];
        for (var i = 0; i < GameSettings.MaxMazeWidth; i++)
        {
            for (var j = 0; j < GameSettings.MaxMazeHeight; j++)
            {
                _map[j, i] = roomFactory.GetRoom();
            }
        }
    }

    public Room GetRoomAt(int x, int y)
    {
        return _map[x, y];
    }

    public void DisplayMap(int xPlayerPosition, int yPlayerPosition)
    {
        for (var i = 0; i < GameSettings.MaxMazeWidth; i++)
        {
            for (int j = 0; j < GameSettings.MaxMazeHeight; j++)
            {
                if (xPlayerPosition == j && yPlayerPosition == i)
                    Console.Write("🧙");
                else
                {
                    Console.Write(_map[j, i].Symbol);
                }
            }
            Console.WriteLine();
        }
    }
}
