using DungeonCrawler.Enums;
using DungeonCrawler.Models;

namespace DungeonCrawler.Services.Interfaces
{
    public interface IMovementService
    {
        bool CheckMove(MoveType move, Player player);
        void Move(MoveType move, Player player);
    }
}