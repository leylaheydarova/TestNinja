using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new CustomerController();
        }
        [Test]
        public void GetCustomer_WhenIdIsZero_ShouldReturnNotFound()
        {
            var result = _controller.GetCustomer(0);
            //There are two ways of assertion of object: TypeOf and InstanceOf. The difference between them is,
            //TypeOf checks if result is NotFound object itself, concurrently;
            //However InstanceOf checks if result is NotFound itself or one of its derivatives objects. (base class)
            Assert.That(result, Is.TypeOf<NotFound>()); //Only NotFound
            //Assert.That(result, Is.InstanceOf<NotFound>()); //Notfound and its derivatives
        }

        [Test]
        public void GetCustomer_WhenIdIsNotZero_ShouldReturnOk()
        {
            var result = _controller.GetCustomer(1);
            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
