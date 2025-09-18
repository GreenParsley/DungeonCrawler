using DungeonCrawler.Models;
using DungeonCrawler.Utils;

namespace DungeonCrawler.Services;

public class DungeonMapService
{
    private readonly Room[,] _map;
    public int Width { get; private set; } = 10;
    public int Height { get; private set; } = 10;

    public DungeonMapService(RoomFactory roomFactory)
    {
        _map = new Room[Width, Height];
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                _map[i, j] = roomFactory.GetRoom();
            }
        }
    }

    public Room GetRoomAt(int x, int y)
    {
        return _map[x, y];
    }
}
