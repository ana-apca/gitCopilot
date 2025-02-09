using NUnit.Framework;

namespace PrimeNumberCheckerTests
{
    [TestFixture]
    public class PrimeNumberCheckerTests
    {
        private PrimeNumberChecker _primeNumberChecker;

        [SetUp]
        public void SetUp()
        {
            _primeNumberChecker = new PrimeNumberChecker();
        }

        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(-5, false)]
        [TestCase(0, false)]
        [TestCase(7919, true)]
        [TestCase(8000, false)]
        public void IsPrime_TestCases(int input, bool expected)
        {
            var result = _primeNumberChecker.IsPrime(input);
            Assert.AreEqual(expected, result);
        }
    }
}
