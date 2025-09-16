using DungeonCrawler.Models;

namespace DungeonCrawlerTests.Models;

public class MonsterTest
{
    private readonly Monster _cut;
    private readonly int _baseHealth = 10;

    public MonsterTest()
    {
        _cut = new Monster("ork", _baseHealth, 2, 0);
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
    public void IsAlive_ReturnsTrue_WhenMonsterIsAlive(int damage)
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
    public void IsAlive_ReturnsFalse_WhenMonsterIsDead(int damage)
    {
        //Arrange
        _cut.TakeDamage(damage);

        //Act
        var result = _cut.IsAlive();

        //Assert
        Assert.False(result);
    }
}
