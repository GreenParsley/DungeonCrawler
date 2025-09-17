using DungeonCrawler.Models;
using DungeonCrawler.Services;
using System;

namespace DungeonCrawler.Utils;

public class ItemFactory
{
    private readonly List<Item> _items = [
        new Item("Rusty Blade", 5, 0, 0),
        new ("Staff of Shadows", 3, 0, 0),
        new ("Shield of Light", 0, 7, 0),
        new ("Cracked Rock Shield", 0, 2, 0),
        new ("Minor Healing Potion", 0, 0, 2),
        new ("Herbal Remedy", 0, 0, 6)
    ];

    public Item CreateItem()
    {
        var itemIndex = DrawService.GetRandomIndex(_items.Count);
        return _items[itemIndex];
    }
}
