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
        primeChecker.IdentifyPrimes();        using System;
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
        
        // Assert
        // Aqui você normalmente afirmaria a saída, mas como IdentifyPrimes escreve no console,
        // pode ser necessário redirecionar a saída do console para testá-la.
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
