using DungeonCrawler.Models;
using DungeonCrawler.Services.Interfaces;
using DungeonCrawler.Utils;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace DungeonCrawler.Services;

[ExcludeFromCodeCoverage]
public class SaveService : ISaveService
{
    private readonly IDungeonMapService _mapService;
    private const string FileName = "save.json";

    public SaveService(IDungeonMapService dungeonMapService)
    {
        _mapService = dungeonMapService;
    }


    public void SaveGame(Player player)
    {
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
        var path = Path.Combine(AppContext.BaseDirectory, FileName);
        var json = JsonSerializer.Serialize(saveModel, options);
        File.WriteAllText(path, json);

        Console.WriteLine($"You saved the game!");
    }

    public SaveModel LoadGame()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "save.json");
        if (!File.Exists(path))
        {
            Console.WriteLine("Save file not found.");
            return null!;
        }

        var json = File.ReadAllText(path);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var saveModel = JsonSerializer.Deserialize<SaveModel>(json, options);
        return saveModel!;
    }

    private List<List<RoomSaveModel>> ConvertMap()
    {
        var mapList = new List<List<RoomSaveModel>>();
        for (int y = 0; y < GameSettings.MaxMazeHeight; y++)
        {
            var row = new List<RoomSaveModel>();
            for (int x = 0; x < GameSettings.MaxMazeWidth; x++)
            {
                var room = _mapService.GetRoomAt(x, y);
                row.Add(new RoomSaveModel
                {
                    EventType = room.Type,
                    WasOpened = room.WasOpened
                });
            }
            mapList.Add(row);
        }
        return mapList;
    }
}
