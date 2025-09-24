using DungeonCrawler.Enums;
using DungeonCrawler.Services.Interfaces;
using DungeonCrawler.Utils;
using DungeonCrawler.Utils.Interfaces;
using DungeonCrawlerTests.Builders;
using FluentAssertions;
using NSubstitute;

namespace DungeonCrawlerTests.Utils;

public class RoomFactoryTest
{
    private readonly RoomFactory _cut;
    private readonly IItemFactory _itemFactory;
    private readonly IMonsterFactory _monsterFactory;
    private readonly IBattleService _battleService;

    public RoomFactoryTest()
    {
        _itemFactory = Substitute.For<IItemFactory>();
        _monsterFactory = Substitute.For<IMonsterFactory>();
        _battleService = Substitute.For<IBattleService>();
        _cut = new RoomFactory(_itemFactory, _monsterFactory, _battleService);
    }

    [Fact]
    public void GetRoom_GetRandomRoom_FromAvailableRooms()
    {
        //Arrange

        //Act
        var result = _cut.GetRoom();

        //Assert
        result.Should().NotBeNull();
        result.WasOpened.Should().BeFalse();
    }
}
