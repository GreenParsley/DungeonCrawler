using DungeonCrawler.Enums;
using DungeonCrawler.Models;
using DungeonCrawler.Services;

namespace DungeonCrawler;

public class App
{
    private readonly MovementService _movementService;
    private readonly GameService _gameService;
    public App(MovementService movementService, GameService gameService)
    {
        _movementService = movementService;
        _gameService = gameService;
    }

    public void Run(string[] args)
    {
        var player = new Player("Jack", 100, 10, 6);
        while (!_gameService.IsOnExit() && !_gameService.IsDead(player))
        {
            var move = GetPlayerMove();
            var isMovePossible = _movementService.CheckMove(move);
            if (!isMovePossible)
            {
                continue;
            }

            player.UseItem();
            _movementService.Move(move, player);
        }

    }

    private MoveType GetPlayerMove()
    {
        Console.WriteLine($"Which way do you want to go?: {MoveType.Left}, {MoveType.Right}, {MoveType.Up} or {MoveType.Down}.");
        while (true)
        {
            try
            {
                var move = Console.ReadLine();
                return Enum.Parse<MoveType>(move);
            }
            catch (Exception)
            {

                Console.WriteLine("Wrong move.");
            }
        }

    }
}
