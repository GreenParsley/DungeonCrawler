using DungeonCrawler.Enums;
using DungeonCrawler.Models;
using DungeonCrawler.Services;
using DungeonCrawler.Services.Interfaces;
using DungeonCrawlerTests.Builders;
using FluentAssertions;
using NSubstitute;

namespace DungeonCrawlerTests.Services;

public class MovementServiceTest
{
    private readonly MovementService _cut;
    private readonly IDungeonMapService _mapService;

    public MovementServiceTest()
    {
        _mapService = Substitute.For<IDungeonMapService>();
        _cut = new MovementService(_mapService);
    }

    [Theory]
    [InlineData(MoveType.Left, 3, 4)]
    [InlineData(MoveType.Right, 5, 4)]
    [InlineData(MoveType.Up, 4, 3)]
    [InlineData(MoveType.Down, 4, 5)]
    public void Move_EntryRoomInNewPosition_WhenPlayerMoves(MoveType move, int expectedX, int expectedY)
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetDefense(1).SetHealth(20).SetXPlayerPosition(4).SetYPlayerPosition(4).Build();
        _mapService.GetRoomAt(expectedX, expectedY).Returns(new EmptyRoom());

        //Act
        _cut.Move(move, player);

        //Assert
        player.XPlayerPosition.Should().Be(expectedX);
        player.YPlayerPosition.Should().Be(expectedY);
    }

    [Theory]
    [InlineData(MoveType.Left)]
    [InlineData(MoveType.Right)]
    [InlineData(MoveType.Up)]
    [InlineData(MoveType.Down)]
    public void CheckMove_ReturnTrue_WhenMoveIsValid(MoveType move)
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetDefense(1).SetHealth(20).SetXPlayerPosition(4).SetYPlayerPosition(4).Build();

        //Act
        var result = _cut.CheckMove(move, player);

        //Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(MoveType.Left, 0, 4)]
    [InlineData(MoveType.Right, 9, 4)]
    [InlineData(MoveType.Up, 4, 0)]
    [InlineData(MoveType.Down, 4, 9)]
    public void CheckMove_ReturnFalse_WhenMoveIsInvalid(MoveType move, int xPlayerPosition, int yPlayerPosition)
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(1).SetDefense(1).SetHealth(20).SetXPlayerPosition(xPlayerPosition).SetYPlayerPosition(yPlayerPosition).Build();

        //Act
        var result = _cut.CheckMove(move, player);

        //Assert
        result.Should().BeFalse();
    }
}
