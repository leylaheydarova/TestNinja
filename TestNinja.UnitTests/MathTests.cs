using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;
        //Setup is calling the instance of the production class before each testing method.
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }
        //If we denote TearDown before instance of prodution class it will call instance after test methods. It is often used in integration tests.

        [Test]
        public void Add_WhenArgumentsAreAandB_ShouldReturnSumOfArguments()
        {
            var a = 4;
            var b = 5;
            var expectedResult = a + b;
            var currentResult = _math.Add(a, b);
            Assert.That(currentResult, Is.EqualTo(expectedResult));
        }

        //Max Method Tests
        #region Different cases in different methods
        [Test]
        [Ignore("Because this is not optimal")]
        public void Max_WhenFirstArgumentIsGreater_ShouldReturnFirstArgument()
        {
            var result = _math.Max(2, 1);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [Ignore("Because this is redundant")]
        public void Max_WhenSecondArgumentIsGreater_ShouldReturnSecondArgument()
        {
            var result = _math.Max(3, 4);
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        [Ignore("Because this is redundant")]
        public void Max_WhenArgumentsAreEqual_ShouldReturnTheSameArgument()
        {
            var result = _math.Max(5, 5);
            Assert.That(result, Is.EqualTo(5));
        }
        #endregion
        //In one test method (above 3 methods may considered as redundant)
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(3, 4, 4)]
        [TestCase(5, 5, 5)]
        public void Max_WhenCalled_ShoulReturnGreaterArgument(int a, int b, int exceptedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(exceptedResult));
        }
    }
}

//To make sure that your test is truthworthy (reliable) create bug on production code, just make some changinf in target line which returns result of the code, if test still passes, your test code is not testing the right thing, this test is not correct. It doesn't pass in some other changes, you can consider this test as trustworthy.
