using DungeonCrawler.Models;
using System.Numerics;
using System.Threading;

namespace DungeonCrawler.Services;

public class BattleService
{
    private readonly Random _bonus = new Random();

    public void Fight(Player player, Monster monster)
    {
        while (true)
        {
            monster.TakeDamage(CountDamage(player.Attack, monster.Defense, player.Name, monster.Name));
            if (!monster.IsAlive())
            {
                Console.WriteLine($"{player.Name} defeated {monster.Name}!");
                return;
            }

            player.TakeDamage(CountDamage(monster.Attack, player.Defense, monster.Name, player.Name));
            if (!player.IsAlive())
            {
                Console.WriteLine($"{monster.Name} defeated {player.Name}!");
                return;
            }
        }
    }

    private int CountDamage(int attack, int defense, string attackerName, string opponentName)
    {
        var damage = attack - defense + _bonus.Next(0, 3);
        if (damage < 1)
        {
            damage = 1;
        }

        Console.WriteLine($"{attackerName} dealt {damage} damage to {opponentName}.");
        return damage;
    }
}
