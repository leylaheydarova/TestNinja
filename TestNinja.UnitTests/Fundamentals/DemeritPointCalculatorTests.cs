using NUnit.Framework;
using System;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointCalculatorTests
    {
        private DemeritPointsCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)] //MaxSpeed is 300
        public void CalculateDemeritPoints_WhenSpeedIsLessThanZeroOrExceedsMaxSpeed_ShouldThrowArgumentOutOfRangeException(int speed)
        {
            Assert.That(() => _calculator.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_WhenSpeedIsUnderOrEqualToLimit_ShouldReturnZero()
        {
            var result = _calculator.CalculateDemeritPoints(1);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_WhenSpeedExceedsLimit_ShouldReturnDemeritPoints()
        {
            var result = _calculator.CalculateDemeritPoints(90);
            Assert.That(result, Is.EqualTo(5));
        }
    }
}
