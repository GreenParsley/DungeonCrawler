using DungeonCrawler.Enums;
using DungeonCrawler.Models;
using DungeonCrawler.Services.Interfaces;
using System.Numerics;

namespace DungeonCrawler;

public class App
{
    private readonly IMovementService _movementService;
    private readonly IGameService _gameService;
    private readonly IDungeonMapService _mapService;
    private readonly IDialogService _dialogService;
    private GameMenuState _lastMenuState = GameMenuState.MainMenu;
    private readonly ISaveService _saveService;

    public App(IMovementService movementService, IGameService gameService, IDungeonMapService mapService, IDialogService dialogService, ISaveService saveService)
    {
        _movementService = movementService;
        _gameService = gameService;
        _mapService = mapService;
        _dialogService = dialogService;
        _saveService = saveService;
    }

    public void Run(string[] args)
    {
        var player = new Player("Jack", 100, 10, 6);
        player.DisplayStats();
        while (!_gameService.IsOnExit(player) && !_gameService.IsDead(player))
        {
            GetPlayerAction(player);
        }
    }

    private void GetPlayerAction(Player player)
    {
        switch(_lastMenuState)
        {
            case GameMenuState.MainMenu:
                var selectedMenu = _dialogService.GetSelectedOptionFromMainMenu();
                _lastMenuState = selectedMenu;
                break;
            case GameMenuState.MovementMenu:
                _mapService.DisplayMap(player.XPlayerPosition, player.YPlayerPosition);
                var action = _dialogService.GetMoveTypeFromMovementMenu();
                if (action == MoveType.Back)
                    _lastMenuState = GameMenuState.MainMenu;
                else
                {
                    var isMovePossible = _movementService.CheckMove(action, player);
                    if (!isMovePossible)
                    {
                        Console.WriteLine("You are at the edge of the labyrinth.");
                        break;
                    }

                    _movementService.Move(action, player);
                    _lastMenuState = GameMenuState.MovementMenu;
                }
                    break;
            case GameMenuState.InventoryMenu:
                var index = _dialogService.GetItemIndexFromInventoryMenu(player);
                if (index == 0)
                    _lastMenuState = GameMenuState.MainMenu;
                else
                {
                    player.UseItem(index - 1);
                    _lastMenuState = GameMenuState.InventoryMenu;
                }
                break;
            case GameMenuState.SaveGame:
                _saveService.SaveGame(player);
                _lastMenuState = GameMenuState.MainMenu;
                break;
            case GameMenuState.CloseGame:
                Environment.Exit(0);
                break;

        }  
    }
}
