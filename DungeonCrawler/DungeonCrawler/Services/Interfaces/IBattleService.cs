using DungeonCrawler.Models;

namespace DungeonCrawler.Services.Interfaces
{
    public interface IBattleService
    {
        void Fight(Player player, Monster monster);
    }
}