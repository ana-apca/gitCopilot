using System;
using Xunit;

public class PrimeNumberChecker
{
    /// <summary>
    /// Identifies and prints prime numbers between 1 and 100.
    /// </summary>
    public void IdentifyPrimes()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i + " is a prime number.");
            }
        }
    }

    /// <summary>
    /// Determines if a given number is prime.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if the number is prime, otherwise false.</returns>
    private bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}

using System;
using Xunit;

/// <summary>
/// The PrimeNumberCheckerTests class contains unit tests for the PrimeNumberChecker class.
/// </summary>
public class PrimeNumberCheckerTests
{
    /// <summary>
    /// Tests the IdentifyPrimes method.
    /// </summary>
    [Fact]
    public void TestIdentifyPrimes()
    {
        // Arrange
        var primeChecker = new PrimeNumberChecker();
        
        // Act
        primeChecker.IdentifyPrimes();
        
        // Assert
        // Aqui você normalmente afirmaria a saída, mas como IdentifyPrimes escreve no console,
        // pode ser necessário redirecionar a saída do console para testá-la.
    }

    /// <summary>
    /// Tests the IsPrime method with various inputs.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <param name="expected">The expected result.</param>
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
