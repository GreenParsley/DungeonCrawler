namespace DungeonCrawler.Interfaces;

public interface ICharacter
{
    string Name { get; }
    int Health { get; }
    int Attack { get; }
    int Defense { get; }

    void TakeDamage(int damage);

    bool IsAlive();
}
