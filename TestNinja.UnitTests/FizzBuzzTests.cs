using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_WhenIsDividedByThreeAndFive_ShouldReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.That(result, Does.Contain("FizzBuzz"));
        }

        [Test]
        public void GetOutput_WhenIsDividedByThree_ShouldReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);
            Assert.That(result, Does.EndWith("Fizz"));
        }

        [Test]
        public void GetOutput_WhenIsDividedByFive_ShouldReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);
            Assert.That(result, Does.StartWith("Buzz"));
        }

        [Test]
        public void GetOutput_WhenIsDividedByOtherNumber_ShouldReturnNumberInString()
        {
            var number = 4;
            var result = FizzBuzz.GetOutput(number);
            Assert.That(result, Is.EqualTo(number.ToString()));
        }
    }
}
