using DungeonCrawler.Models;
using DungeonCrawler.Services;

namespace DungeonCrawler.Utils;

public class MonsterFactory
{
    private readonly List<(string Name, int Health, int Attack, int Defense, int Level)> _monsterTemplates =
    [
        ("Cave Rat", 10, 5, 0, 1),
        ("Slime Blob", 15, 7, 2, 1),
        ("Orc Brute", 19, 10, 5, 2),
        ("Ghoul", 26, 11, 6, 2),
        ("Vampire Lord", 35, 15, 10, 3),
        ("Necromancer", 60, 20, 15, 4)
    ];

    private readonly Dictionary<int, int> _threshold = new()
    {
        {0, 1},
        {5, 2},
        {10,3},
        {15,4}
    };

    public Monster CreateMonster(int xPlayerPosition, int yPlayerPosition)
    {
        var distance = xPlayerPosition + yPlayerPosition;
        var maxAvailableLevel = _threshold
            .Where(x => distance >= x.Key)
            .Select(x => x.Value)
            .DefaultIfEmpty(1)
            .Max();

        var availableTemplates = _monsterTemplates
            .Where(t => t.Level <= maxAvailableLevel)
            .ToList();
        var monsterIndex = DrawService.GetRandomIndex(availableTemplates.Count);
        var template = availableTemplates[monsterIndex];
        return new Monster(template.Name, template.Health, template.Attack, template.Defense, template.Level);
    }
}
