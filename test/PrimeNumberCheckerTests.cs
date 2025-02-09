using System;
using Xunit;

public class PrimeNumberCheckerTests
{
    [Fact]
    public void TestIdentifyPrimes()
    {
        // Arrange
        var primeChecker = new PrimeNumberChecker();
        
        // Act
        primeChecker.IdentifyPrimes();
        
        // Assert
        // Here you would typically assert the output, but since IdentifyPrimes writes to console,
        // you might need to redirect the console output to test it.
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(17, true)]
    [InlineData(18, false)]
    public void TestIsPrime(int number, bool expected)
    {
        // Arrange
        var primeChecker = new PrimeNumberChecker();
        
        // Act
        var result = primeChecker.IsPrime(number);
        
        // Assert
        Assert.Equal(expected, result);
    }
}
