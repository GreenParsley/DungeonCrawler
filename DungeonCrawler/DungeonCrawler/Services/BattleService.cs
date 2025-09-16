using DungeonCrawler.Models;

namespace DungeonCrawler.Services;

public class BattleService
{
    private readonly Random _bonus = new Random();

    public string Fight(Player player, Monster monster)
    {
        while (player.IsAlive() && monster.IsAlive())
        {
            int playerBonus = _bonus.Next(1, 10);
            int playerDamage = player.Attack - monster.Defense + playerBonus;
            monster.TakeDamage(playerDamage);

            if (!monster.IsAlive())
            {
                return $"{player.Name} defeated {monster.Name}!";
            }

            int monsterBonus = _bonus.Next(1, 10);
            int monsterDamage = monster.Attack - player.Defense + monsterBonus;
            player.TakeDamage(monsterDamage);

            if (!player.IsAlive())
            {
                return $"{monster.Name} defeated {player.Name}!";
            }
        }
        return "The fight ended in a draw.";
    }
}
