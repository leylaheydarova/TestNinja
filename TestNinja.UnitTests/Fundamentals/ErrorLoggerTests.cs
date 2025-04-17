using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }
        [Test]
        public void Log_WhenCalled_ShouldSetTheLastErrorProperty()
        {
            _logger.Log("some error"); //void method testing
            Assert.That(_logger.LastError, Is.EqualTo("some error"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_WhenInvalidError_ShouldThrowArgumentNullException(string error)
        {
            Assert.That(() => _logger.Log(error), Throws.ArgumentNullException); //this is for system exceptions
            //for custom exception
            //Assert.Throws(() => _logger.Log(error), Throws.Exception.TypeOf<HereIsCustomExceptionName>);
        }

        [Test]
        public void Log_ValidError_ShouldRaiseErrorLoggedEvent()
        {
            var id = Guid.Empty;
            //firstly, we have to subscribe to that event
            _logger.ErrorLogged += (sender, args) => { id = args; }; //body of function assigns some guid to id. result will any guid sequence except empty guid.
            
            _logger.Log("error"); //call the method
            
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
