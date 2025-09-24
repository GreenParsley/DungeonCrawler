using DungeonCrawler.Models;

namespace DungeonCrawler.Utils.Interfaces
{
    public interface IMonsterFactory
    {
        Monster CreateMonster(int xPlayerPosition, int yPlayerPosition);
    }
}