using DungeonCrawler.Models;
using DungeonCrawler.Services.Interfaces;
using DungeonCrawler.Utils;
using DungeonCrawler.Utils.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DungeonCrawler.Services;

[ExcludeFromCodeCoverage]
public class DungeonMapService : IDungeonMapService
{
    private readonly Room[,] _map;
    private readonly IRoomFactory _roomFactory;

    public DungeonMapService(IRoomFactory roomFactory)
    {
        _roomFactory = roomFactory;
        _map = new Room[GameSettings.MaxMazeWidth, GameSettings.MaxMazeHeight];
        for (var i = 0; i < GameSettings.MaxMazeWidth; i++)
        {
            for (var j = 0; j < GameSettings.MaxMazeHeight; j++)
            {
                _map[j, i] = _roomFactory.GetRoom(i == 0 && j == 0);
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
        Console.WriteLine();
    }

    public void LoadRooms(List<List<RoomSaveModel>> map)
    {
        for (var i = 0; i < GameSettings.MaxMazeWidth; i++)
        {
            for (var j = 0; j < GameSettings.MaxMazeHeight; j++)
            {
                _map[j, i] = _roomFactory.GetRoom(map[i][j]);
            }
        }
    }
}
