using DungeonCrawler.Enums;

namespace DungeonCrawler.Models;

public class SaveModel
{
    public PlayerSaveModel Player { get; set; } = null!;
    public List<List<RoomSaveModel>> Map { get; set; } = null!;
    public int PlayerX { get; set; }
    public int PlayerY { get; set; }
}

public class PlayerSaveModel
{
    public string Name { get; set; } = null!;
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
}

public class RoomSaveModel
{
    public RoomEventType EventType { get; set; }
    public bool WasOpened { get; set; }
}
