using DungeonCrawler.Models;
using DungeonCrawler.Services;
using DungeonCrawler.Utils;
using DungeonCrawlerTests.Builders;
using FluentAssertions;
using System.Text.Json;

namespace DungeonCrawlerTests.Services;

public class GameServiceTest
{
    private readonly GameService _cut;

    public GameServiceTest()
    {
        _cut = new GameService();
    }

    [Fact]
    public void IsOnExit_ReturnTrue_WhenPlayerFoundExit()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetHealth(20).SetXPlayerPosition(9).SetYPlayerPosition(9).Build();

        //Act
        var result = _cut.IsOnExit(player);

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsOnExit_ReturnFalse_WhenPlayerIsStillInLabyrinth()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetHealth(20).SetXPlayerPosition(9).SetYPlayerPosition(8).Build();

        //Act
        var result = _cut.IsOnExit(player);

        //Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void IsDead_ReturnTrue_WhenPlayerIsDead()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetHealth(0).Build();

        //Act
        var result = _cut.IsDead(player);

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsDead_ReturnFalse_WhenPlayerIsNotDead()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetHealth(40).Build();

        //Act
        var result = _cut.IsDead(player);

        //Assert
        result.Should().BeFalse();
    }
}
