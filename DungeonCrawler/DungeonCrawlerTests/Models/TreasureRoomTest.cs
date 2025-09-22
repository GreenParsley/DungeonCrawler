using DungeonCrawler.Models;
using DungeonCrawler.Utils;
using DungeonCrawlerTests.Builders;
using FluentAssertions;
using NSubstitute;

namespace DungeonCrawlerTests.Models;

public class TreasureRoomTest
{
    private readonly TreasureRoom _cut;
    private readonly ItemFactory _factory;

    public TreasureRoomTest()
    {
        _factory = Substitute.For<ItemFactory>();
        _cut = new TreasureRoom(_factory);
    }

    [Fact]
    public void Enter_FoundItem_WhenPlayerEnterTheTreasureRoom()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetDefense(1).SetHealth(1).Build();

        //Act
        _cut.Enter(player);

        //Assert
        _cut.Symbol.Should().Be("💰");
        _cut.WasOpened.Should().BeTrue();
        player.Inventory.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public void Enter_RoomIsEmpty_WhenPlayerReenterRoom()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetDefense(1).SetHealth(1).Build();
        _cut.Enter(player);

        //Act
        _cut.Enter(player);

        //Assert
        _cut.Symbol.Should().Be("💰");
        _cut.WasOpened.Should().BeTrue();
        player.Inventory.Should().HaveCount(1);
    }
}
