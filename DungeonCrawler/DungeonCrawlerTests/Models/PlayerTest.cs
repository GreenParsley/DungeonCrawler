using DungeonCrawler.Models;

namespace DungeonCrawlerTests.Models;

public class PlayerTest
{
    private readonly Player _cut;
    private readonly int _baseHealth = 10;

    public PlayerTest()
    {
        _cut = new Player("ork slayer", _baseHealth, 3, 2);
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
}
