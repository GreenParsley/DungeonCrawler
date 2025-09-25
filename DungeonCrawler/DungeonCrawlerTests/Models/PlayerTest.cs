using DungeonCrawler.Models;
using DungeonCrawlerTests.Builders;
using FluentAssertions;

namespace DungeonCrawlerTests.Models;

public class PlayerTest
{
    private readonly Player _cut;
    private readonly int _baseHealth = 10;
    private readonly int _baseAttack = 3;
    private readonly int _baseDefense = 2;

    public PlayerTest()
    {
        _cut = new Player("ork slayer", _baseHealth, _baseAttack, _baseDefense);
    }

    [Theory]
    [InlineData(15)]
    [InlineData(10)]
    [InlineData(2)]
    [InlineData(0)]
    public void TakeDamage_LoseHealthPoints_WhenGetsDamage(int validDamageValue)
    {
        //Arrange

        //Act
        _cut.TakeDamage(validDamageValue);

        //Assert
        _cut.Health.Equals(_baseHealth - validDamageValue);
    }

    [Theory]
    [InlineData(9)]
    [InlineData(1)]
    [InlineData(0)]
    public void IsAlive_ReturnsTrue_WhenPlayerIsAlive(int damage)
    {
        //Arrange
        _cut.TakeDamage(damage);

        //Act
        var result = _cut.IsAlive();

        //Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(100)]
    [InlineData(99999)]
    public void IsAlive_ReturnsFalse_WhenPlayerIsDead(int damage)
    {
        //Arrange
        _cut.TakeDamage(damage);

        //Act
        var result = _cut.IsAlive();

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddItem_SuccessfullyAddItem_WhenAddingNewItem()
    {
        //Arrange
        var item = new ItemBuilder().SetName("Item").SetAttackBonus(1).SetDefenseBonus(1).SetHealing(1).Build();

        //Act
        _cut.AddItem(item);

        //Assert
        _cut.Inventory.Should().Contain(item);
    }

    [Fact]
    public void UseItem_UseAndRemoveUsedItem_WhenPlayyerUsesItem()
    {
        //Arrange
        var bonus = 1;
        var item = new ItemBuilder().SetName("Item").SetAttackBonus(bonus).SetDefenseBonus(bonus).SetHealing(bonus).Build();
        _cut.AddItem(item);

        //Act
        _cut.UseItem(0);

        //Assert
        _cut.Inventory.Count.Should().Be(0);
        _cut.Attack.Should().Be(_baseAttack + bonus);
        _cut.Defense.Should().Be(_baseDefense + bonus);
        _cut.Health.Should().Be(_baseHealth + bonus);
    }
}
