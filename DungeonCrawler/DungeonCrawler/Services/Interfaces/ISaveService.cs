using DungeonCrawler.Models;

namespace DungeonCrawler.Services.Interfaces
{
    public interface ISaveService
    {
        void SaveGame(Player player);
    }
}