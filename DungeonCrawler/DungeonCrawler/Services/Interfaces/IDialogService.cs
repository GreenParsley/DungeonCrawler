using DungeonCrawler.Enums;
using DungeonCrawler.Models;

namespace DungeonCrawler.Services.Interfaces
{
    public interface IDialogService
    {
        int GetItemIndexFromInventoryMenu(Player player);
        MoveType GetMoveTypeFromMovementMenu();
        GameMenuState GetSelectedOptionFromMainMenu();
    }
}