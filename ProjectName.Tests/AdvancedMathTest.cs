namespace ProjectName.Tests;

public class AdvancedMathTest
{
    [Fact]
    public void Subtract_ZeroFromZero_ReturnsZero()
    {
        // arrange
        var advancedMath = new AdvancedMath();

        // act
        var actual = advancedMath.Subtract(0, 0);

        // assign
        Assert.Equal(0, actual);

    }
}
