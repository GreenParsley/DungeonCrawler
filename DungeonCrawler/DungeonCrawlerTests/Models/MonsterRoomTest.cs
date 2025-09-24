using DungeonCrawler.Models;
using DungeonCrawler.Services.Interfaces;
using DungeonCrawler.Utils.Interfaces;
using DungeonCrawlerTests.Builders;
using FluentAssertions;
using NSubstitute;

namespace DungeonCrawlerTests.Models;

public class MonsterRoomTest
{
    private readonly MonsterRoom _cut;
    private readonly IMonsterFactory _factory;
    private readonly IBattleService _battleService;

    public MonsterRoomTest()
    {
        _factory = Substitute.For<IMonsterFactory>();
        _battleService = Substitute.For<IBattleService>();
        _cut = new MonsterRoom(_factory, _battleService);
    }

    [Fact]
    public void Enter_MeetMonster_WhenPlayerEntersTheMonsterRoom()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetDefense(1).SetHealth(20).Build();
        var monster = new Monster("Ogr", 1, 1, 1, 1);
        _factory.CreateMonster(player.XPlayerPosition, player.YPlayerPosition).Returns(monster);

        //Act
        _cut.Enter(player);

        //Assert
        _cut.Symbol.Should().Be("💀");
        _cut.WasOpened.Should().BeTrue();
        _battleService.Received(1).Fight(player, monster);
    }

    [Fact]
    public void Enter_RoomIsEmpty_WhenPlayerReenterRoom()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetDefense(1).SetHealth(20).Build();
        var monster = new Monster("Ogr", 1, 1, 1, 1);
        _factory.CreateMonster(player.XPlayerPosition, player.YPlayerPosition).Returns(monster);
        _cut.Enter(player);

        //Act
        _cut.Enter(player);


        //Assert
        _cut.Symbol.Should().Be("💀");
        _cut.WasOpened.Should().BeTrue();
        _battleService.Received(1).Fight(player, monster);
    }
}
