using DungeonCrawler.Models;
using DungeonCrawler.Utils;

namespace DungeonCrawler.Services;

public class DungeonMapService
{
    private readonly Room[,] _map;

    public DungeonMapService(RoomFactory roomFactory)
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
