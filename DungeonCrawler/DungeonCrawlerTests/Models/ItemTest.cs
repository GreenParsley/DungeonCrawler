using DungeonCrawler.Models;
using DungeonCrawlerTests.Builders;
using FluentAssertions;

namespace DungeonCrawlerTests.Models;

public class ItemTest
{
    private readonly Item _cut;

    public ItemTest()
    {
        _cut = new Item("Minor item", 1, 2, 3);
    }

    [Fact]
    public void Use_IncreaseStats_WhenUsingItem()
    {
        //Arrange
        var player = new PlayerBuilder().SetName("Jake").SetAttack(0).SetDefense(0).SetHealth(0).Build();

        //Act
        _cut.Use(player);

        //Assert
        player.Health.Should().Be(_cut.Healing);
        player.Attack.Should().Be(_cut.AttackBonus);
        player.Defense.Should().Be(_cut.DefenseBonus);
    }
}