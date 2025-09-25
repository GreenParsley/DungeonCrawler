using DungeonCrawler.Models;
using DungeonCrawler.Utils;
using DungeonCrawlerTests.Builders;
using FluentAssertions;

namespace DungeonCrawlerTests.Models;

public class TrapRoomTest
{
    private readonly TrapRoom _cut;

    public TrapRoomTest()
    {
        _cut = new TrapRoom(false);
    }

    [Fact]
    public void Enter_TakeDamage_WhenPlayerEntersTheTrapRoom()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetDefense(1).SetHealth(20).Build();

        //Act
        _cut.Enter(player);

        //Assert
        _cut.Symbol.Should().Be("⚠️");
        _cut.WasOpened.Should().BeTrue();
        player.Health.Should().Be(10);
    }

    [Fact]
    public void Enter_RoomIsEmpty_WhenPlayerReentersRoom()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetDefense(1).SetHealth(20).Build();
        _cut.Enter(player);

        //Act
        _cut.Enter(player);

        //Assert
        _cut.Symbol.Should().Be("⚠️");
        _cut.WasOpened.Should().BeTrue();
        player.Health.Should().Be(10);
    }
}
