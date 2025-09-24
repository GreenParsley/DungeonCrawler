using DungeonCrawler.Models;

namespace DungeonCrawler.Services.Interfaces
{
    public interface IGameService
    {
        bool IsDead(Player player);
        bool IsOnExit(Player player);
    }
}