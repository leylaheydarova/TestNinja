using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldReturnStrongFormat()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("Leyla");

            //specific assertion for string
            Assert.That(result, Is.EqualTo("<strong>Leyla</strong>")); //but if you do some changing in production code string you can forget about that changing in test expected outcome, and that will break test. That's why it is recommended to use more generic (but not too generic) assertions.

            //more generic assertions for string
            //we can separete string outcome(message) with some parts.
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase); //
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain("Leyla")); //But still there may cause some bugs in the production code. Both assertion approaches are pros and cons, those are mentioned below.
        }
    }
}
//Pros of specific approach: Trustworthy is in the highest level, provides more bug-free condition.
//Cons of specific approach: You can change in exceptec string everytime when you change production code string. Otherwise, test will break.

//Pros of more generic approach: Reduces the changing breaks in strings.
//Cons of more generic approach: Trustworthy and bug-free is in lower level.