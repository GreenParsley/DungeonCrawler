using DungeonCrawler.Enums;
using DungeonCrawler.Models;
using DungeonCrawler.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace DungeonCrawler.Services;

[ExcludeFromCodeCoverage]
public class DialogService : IDialogService
{
    public GameMenuState GetSelectedOptionFromMainMenu()
    {
        return CommunicationService.GetEnumChoice<GameMenuState>("2 - Move\n3 - Inventory\n8 - Load\n9 - Save\n0 - Close\n",
            GameMenuState.InventoryMenu, GameMenuState.MovementMenu, GameMenuState.LoadGame, GameMenuState.SaveGame, GameMenuState.CloseGame);
    }

    public MoveType GetMoveTypeFromMovementMenu()
    {
        return CommunicationService.GetEnumChoice<MoveType>("Left = 1\nRight = 2\nUp = 3\nDown = 4\nBack = 0\n",
            MoveType.Left, MoveType.Right, MoveType.Up, MoveType.Down, MoveType.Back);
    }

    public int GetItemIndexFromInventoryMenu(Player player)
    {
        string message = "";
        for (int i = 0; i < player.Inventory.Count; i++)
        {
            message += $"{i + 1} - {player.Inventory[i].Name}\n";
        }

        message += "0 - Back\n";
        return CommunicationService.GetIndex(message, player.Inventory.Count + 1);
    }
}
