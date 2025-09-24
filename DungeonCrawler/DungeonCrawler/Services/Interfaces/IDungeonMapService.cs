using DungeonCrawler.Models;

namespace DungeonCrawler.Services.Interfaces
{
    public interface IDungeonMapService
    {
        void DisplayMap(int xPlayerPosition, int yPlayerPosition);
        Room GetRoomAt(int x, int y);
    }
}