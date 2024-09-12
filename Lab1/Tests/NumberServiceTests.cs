using App;
using Xunit.Abstractions;

namespace Tests;

public class NumberServiceTests
{
    private readonly ITestOutputHelper _output;

    public NumberServiceTests(ITestOutputHelper output) => _output = output;

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(0, 0)]
    [InlineData(-1, 1)]
    [InlineData(1, -1)]
    [InlineData(-1, -1)]
    public void FindMaxForSumAndDigitsCount_ThrowsArgumentException_WhenSumOrDigitsCountIsLessThanOne(int sum, int digitsCount)
    {
        // Act
        Action act = () => NumberService.FindMaxForSumAndDigitsCount(sum, digitsCount);

        // Assert
        _ = Assert.Throws<ArgumentException>(act);
        _output.WriteLine($"{nameof(FindMaxForSumAndDigitsCount_ThrowsArgumentException_WhenSumOrDigitsCountIsLessThanOne)}: {sum}, {digitsCount} - passed");
    }

    [Theory]
    [InlineData(10, 1)]
    [InlineData(19, 2)]
    [InlineData(20, 2)]
    public void FindMaxForSumAndDigitsCount_ThrowsArgumentException_WhenSumIsGreaterThanNineTimesDigitsCount(int sum, int digitsCount)
    {
        // Act
        Action act = () => NumberService.FindMaxForSumAndDigitsCount(sum, digitsCount);

        // Assert
        _ = Assert.Throws<ArgumentException>(act);
        _output.WriteLine($"{nameof(FindMaxForSumAndDigitsCount_ThrowsArgumentException_WhenSumIsGreaterThanNineTimesDigitsCount)}: {sum}, {digitsCount} - passed");
    }

    [Theory]
    [InlineData(1, 1, "1")]
    [InlineData(9, 1, "9")]
    [InlineData(10, 4, "9100")]
    [InlineData(11, 4, "9200")]
    public void FindMaxForSumAndDigitsCount_ReturnsExpectedResult(int sum, int digitsCount, string expected)
    {
        // Act
        var actual = NumberService.FindMaxForSumAndDigitsCount(sum, digitsCount);

        // Assert
        Assert.Equal(expected, actual);
        _output.WriteLine($"{nameof(FindMaxForSumAndDigitsCount_ReturnsExpectedResult)}: {sum}, {digitsCount}, {expected} - passed");
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(0, 0)]
    [InlineData(-1, 1)]
    [InlineData(1, -1)]
    [InlineData(-1, -1)]
    public void FindMinForSumAndDigitsCount_ThrowsArgumentException_WhenSumOrDigitsCountIsLessThanOne(int sum, int digitsCount)
    {
        // Act
        Action act = () => NumberService.FindMinForSumAndDigitsCount(sum, digitsCount);

        // Assert
        _ = Assert.Throws<ArgumentException>(act);
        _output.WriteLine($"{nameof(FindMinForSumAndDigitsCount_ThrowsArgumentException_WhenSumOrDigitsCountIsLessThanOne)}: {sum}, {digitsCount} - passed");
    }

    [Theory]
    [InlineData(10, 1)]
    [InlineData(19, 2)]
    [InlineData(20, 2)]
    public void FindMinForSumAndDigitsCount_ThrowsArgumentException_WhenSumIsGreaterThanNineTimesDigitsCount(int sum, int digitsCount)
    {
        // Act
        Action act = () => NumberService.FindMinForSumAndDigitsCount(sum, digitsCount);

        // Assert
        _ = Assert.Throws<ArgumentException>(act);
        _output.WriteLine($"{nameof(FindMinForSumAndDigitsCount_ThrowsArgumentException_WhenSumIsGreaterThanNineTimesDigitsCount)}: {sum}, {digitsCount} - passed");
    }

    [Theory]
    [InlineData(1, 1, "1")]
    [InlineData(9, 1, "9")]
    [InlineData(10, 4, "1009")]
    [InlineData(11, 4, "1019")]
    public void FindMinForSumAndDigitsCount_ReturnsExpectedResult(int sum, int digitsCount, string expected)
    {
        // Act
        var actual = NumberService.FindMinForSumAndDigitsCount(sum, digitsCount);

        // Assert
        Assert.Equal(expected, actual);
        _output.WriteLine($"{nameof(FindMinForSumAndDigitsCount_ReturnsExpectedResult)}: {sum}, {digitsCount}, {expected} - passed");
    }
}
