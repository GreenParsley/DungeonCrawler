using DungeonCrawler.Models;
using DungeonCrawler.Services;
using DungeonCrawlerTests.Builders;
using FluentAssertions;

namespace DungeonCrawlerTests.Services;

public class BattleServiceTest
{
    private readonly BattleService _cut;

    public BattleServiceTest()
    {
        _cut = new BattleService();
    }

    [Fact]
    public void Fight_PlayerWin_WhenDefeatsMonster()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(15).SetHealth(40).Build();
        var monster = new Monster("Orc", 10, 1, 1, 1);

        //Act
        _cut.Fight(player, monster);

        //Assert
        player.IsAlive().Should().BeTrue();
        monster.IsAlive().Should().BeFalse();
    }

    [Fact]
    public void Fight_MonsterWin_WhenDefeatsPlayer()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetHealth(10).Build();
        var monster = new Monster("Orc", 40, 15, 1, 1);

        //Act
        _cut.Fight(player, monster);

        //Assert
        player.IsAlive().Should().BeFalse();
        monster.IsAlive().Should().BeTrue();
    }
}
