using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Push_WhenObjIsNull_ShouldThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ObjIsNotNull_ShouldAddObject()
        {
            _stack.Push("Leyla");
            Assert.That(_stack.Count, Is.Not.EqualTo(0));
        }

        [Test]
        public void Pop_WhenCountIsZero_ShouldThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenCountIsNotZero_ShouldRemoveLastObj()
        {
            _stack.Push("Zohrab");
            _stack.Push("Kamile");
            var currentCount = _stack.Count;
            _stack.Pop();
            Assert.That(_stack.Count, Is.EqualTo(currentCount - 1));
        }

        [Test]
        public void Pop_WhenCountIsNotZero_ShouldReturnLastObj()
        {
            _stack.Push("Zohrab");
            _stack.Push("Kamile");
            var currentCount = _stack.Count;
            var result = _stack.Pop();
            Assert.That(result, Is.EqualTo("kamile").IgnoreCase);
        }

        [Test]
        public void Peek_WhenCountIsZero_ShouldThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenCountIsNotZero_ShouldReturnLastObject()
        {
            _stack.Push("Ruslan");
            _stack.Push("Sona");
            var result = _stack.Peek();
            Assert.That(result, Does.Contain("Sona"));
        }
    }
}
