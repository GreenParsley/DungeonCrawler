using DungeonCrawler.Utils;
using FluentAssertions;

namespace DungeonCrawlerTests.Utils;

public class MonsterFactoryTest
{
    private readonly MonsterFactory _cut;

    public MonsterFactoryTest()
    {
        _cut = new MonsterFactory();
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 4)]
    [InlineData(5, 6)]
    [InlineData(8, 8)]
    public void CreateMonster_ReturnMonster_WhenPlayerGetCloserToExit(int xPlayerPosition, int yPlayerPosition)
    {
        //Arrange

        //Act
        var result = _cut.CreateMonster(xPlayerPosition, yPlayerPosition);

        //Assert
        result.Should().NotBeNull();
    }
}
