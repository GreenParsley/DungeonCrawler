using DungeonCrawler.Models;
using DungeonCrawler.Services;

namespace DungeonCrawler.Utils;

public class MonsterFactory
{
    private readonly List<Monster> _monsters = [
        new Monster("Cave Rat", 5, 1, 0),
        new ("Slime Blob", 7, 1, 2),
        new ("Orc Brute", 15, 5, 2),
        new ("Ghoul", 20, 6, 4),
        new ("Vampire Lord", 35, 15, 10),
        new ("Necromancer", 60, 20, 15)
    ];

    public Monster CreateMonster()
    {
        var monsterIndex = DrawService.GetRandomIndex(_monsters.Count);
        return _monsters[monsterIndex];
    }
}
