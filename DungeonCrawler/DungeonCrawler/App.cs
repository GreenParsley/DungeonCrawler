using DungeonCrawler.Enums;
using DungeonCrawler.Models;
using DungeonCrawler.Services;

namespace DungeonCrawler;

public class App
{
    private readonly MovementService _movementService;
    private readonly GameService _gameService;
    private readonly DungeonMapService _mapService;

    public App(MovementService movementService, GameService gameService, DungeonMapService mapService)
    {
        _movementService = movementService;
        _gameService = gameService;
        _mapService = mapService;
    }

    public void Run(string[] args)
    {
        var player = new Player("Jack", 100, 10, 6);
        player.DisplayStats();
        while (!_gameService.IsOnExit(player) && !_gameService.IsDead(player))
        {
            _mapService.DisplayMap(player.XPlayerPosition, player.YPlayerPosition);
            player.UseItem();
            var move = GetPlayerMove();
            var isMovePossible = _movementService.CheckMove(move, player);
            if (!isMovePossible)
            {
                Console.WriteLine("You are at the edge of the labyrinth.");
                continue;
            }

            _movementService.Move(move, player);
        }

    }

    private MoveType GetPlayerMove()
    {
        var message = $"Which way do you want to go?: {MoveType.Left}, {MoveType.Right}, {MoveType.Up} or {MoveType.Down}.";
        var move = CommunicationService.GetValue(message, MoveType.Left.ToString(), MoveType.Right.ToString(), MoveType.Up.ToString(), MoveType.Down.ToString());
        return Enum.Parse<MoveType>(move, true);
    }
}
