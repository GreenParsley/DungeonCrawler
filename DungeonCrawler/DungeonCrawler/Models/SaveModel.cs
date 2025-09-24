using DungeonCrawler.Enums;

namespace DungeonCrawler.Models;

public class SaveModel
{
    public PlayerSaveModel Player { get; set; }
    public RoomSaveModel[,] Map { get; set; }
    public int PlayerX { get; set; }
    public int PlayerY { get; set; }
}

public class PlayerSaveModel
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
}

public class RoomSaveModel
{
    public RoomEventType EventType { get; set; }
    public bool WasOpened { get; set; }
}
