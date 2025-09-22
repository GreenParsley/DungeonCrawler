using FluentAssertions;

namespace DungeonCrawlerTests.Services;

public class DrawServiceTest
{
    [Fact]
    public void GetRandomIndex_ReturnsRandomNumber_InSelectedRange()
    {
        //Arrange
        Random random = new Random();

        //Act
        var result = random.Next(0, 5);

        //Assert
        result.Should().BeInRange(0, 5);
    }
}
