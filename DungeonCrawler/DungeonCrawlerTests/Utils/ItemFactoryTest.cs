using DungeonCrawler.Models;
using DungeonCrawler.Utils;
using FluentAssertions;

namespace DungeonCrawlerTests.Utils;

public class ItemFactoryTest
{
    private readonly ItemFactory _cut;

    public ItemFactoryTest()
    {
        _cut = new ItemFactory();
    }

    [Fact]
    public void CreateItem_CreateRandomItem_WhenPlayerIsInTreasureRoom()
    {
        //Arrange

        //Act
        var result = _cut.CreateItem();

        //Assert
        result.Should().NotBeNull();
    }
}
