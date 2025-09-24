using DungeonCrawler.Models;
using DungeonCrawler.Services.Interfaces;
using DungeonCrawler.Utils;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace DungeonCrawler.Services;

public class SaveService
{
    private readonly IDungeonMapService _mapService;

    public SaveService(IDungeonMapService dungeonMapService)
    {
            _mapService = dungeonMapService;
    }


    public void SaveGame(Player player, string filePath)
    {
        var message = "Do you want to save the game? y/n";
        var respond = CommunicationService.GetValue(message);
        if (respond is "n")
        {
            return;
        }
        if (respond is not "y")
        {
            Console.WriteLine("Wrong action");
            return;
        }
        var saveModel = new SaveModel
        {
            Player = new PlayerSaveModel
            {
                Name = player.Name,
                Attack = player.Attack,
                Defense = player.Defense,
                Health = player.Health,
            },
            PlayerX = player.XPlayerPosition,
            PlayerY = player.YPlayerPosition,
            Map = ConvertMap()
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(saveModel, options);
    }

    private RoomSaveModel[,] ConvertMap()
    {
        var map = new RoomSaveModel[GameSettings.MaxMazeWidth, GameSettings.MaxMazeHeight];
        for (var i = 0; i < GameSettings.MaxMazeWidth; i++)
        {
            for (var j = 0; j < GameSettings.MaxMazeHeight; j++)
            {
                var room = _mapService.GetRoomAt(j, i);
                map[j, i] = new RoomSaveModel
                {
                    EventType = room.Type,
                    WasOpened = room.WasOpened
                };
            }
        }

        return map;
    }
}
