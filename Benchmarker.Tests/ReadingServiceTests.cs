using Xunit;

namespace Benchmarker.Tests;

public class ReadingServiceTests
{
    [Fact]
    public void ValidateBySteps_ReturnsInvalidReadings()
    {
        // Arrange
        var readingService = new ReadingService();

        // Act
        var result = readingService.IterateBySteps();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }
    
    [Fact]
    public void ValidateByReadings_ReturnsInvalidReadings()
    {
        // Arrange
        var readingService = new ReadingService();

        // Act
        var result = readingService.IterateByReadings();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}