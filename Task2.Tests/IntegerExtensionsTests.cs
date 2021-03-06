using System;
using NUnit.Framework;
using static Task2.IntegerExtensions;

namespace Task2.Tests
{
    public class IntegerExtensionsTests
    {
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(12, 60, ExpectedResult = 12)]
        [TestCase(2672, 5678, ExpectedResult = 334)]
        [TestCase(10927782, 6902514, ExpectedResult = 846)]
        [TestCase(1590771464, 1590771620, ExpectedResult = 4)]
        [Order(1)]
        public int GcdTests_WithAllPositiveNumbers(int a, int b) => GetGcd(a, b);

        
        [Timeout(3000)]
        [Order(3)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        [TestCase(-1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-10234562, -7872334, ExpectedResult = 2)]
        [TestCase(1590771464, -1590771620, ExpectedResult = 4)]
        [TestCase(-10234567, -234568989, ExpectedResult = 97)]
        public int GcdTests_WithSomeNegativeNumbers(int a, int b) => GetGcd(a, b);

        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(0, -301, ExpectedResult = 301)]
        [TestCase(10927782, 0, ExpectedResult = 10927782)]
        [TestCase(-1590771464, 0, ExpectedResult = 1590771464)]
        [Timeout(3000)]
        [Order(4)]
        public int GcdTests_WithOneZeroNumber(int a, int b) => GetGcd(a, b);

        [TestCase(int.MaxValue, int.MinValue, ExpectedResult = 1)]
        [Property("Mark", 2)]
        [Timeout(10000)]
        [Order(5)]
        public int GcdTest_WithMaxAndMinIntegerNumbers(int a, int b) => GetGcd(a, b);

        [Test, Order(2)]
        public void GcdTest_WithTwoZeroNumbers_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GetGcd(0, 0),
                "Two numbers cannot be 0 at the same time.");
        [Test]
        public void GcdTest_WithMinIntegerAndZero_ThrowOverFlowException() =>
            Assert.Throws<OverflowException>(() => GetGcd(int.MinValue, 0),
                "OverFlow_NegateTwosCompNum");
    }
}