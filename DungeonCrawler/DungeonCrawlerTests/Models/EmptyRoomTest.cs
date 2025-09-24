using DungeonCrawler.Models;
using DungeonCrawlerTests.Builders;
using FluentAssertions;

namespace DungeonCrawlerTests.Models;

public class EmptyRoomTest
{
    private readonly EmptyRoom _cut;

    public EmptyRoomTest()
    {
        _cut = new EmptyRoom();
    }

    [Fact]
    public void Enter_DoNothing_WhenPlayerEnterTheEmptyRoom()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetDefense(1).SetHealth(1).Build();

        //Act
        _cut.Enter(player);

        //Assert
        _cut.Symbol.Should().Be("🔓");
        _cut.WasOpened.Should().BeTrue();
    }
}
