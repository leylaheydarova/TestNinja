using Moq;
using NUnit.Framework;
using System;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        OrderService _service;
        Mock<IStorage> _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IStorage>();
            _service = new OrderService(_storage.Object);
        }

        [Test]
        public void PlaceOrder_WhenCalled_ShouldStoreOrder()
        {
            var order = new Order();
            _service.PlaceOrder(order);
            _storage.Verify(s => s.Store(order));
        }

        [Test]
        public void PlaceOrder_WhenCalled_ShouldReturnOrderId()
        {
            var order = new Order() { OrderId = Guid.NewGuid() };
            var orderId = _service.PlaceOrder(order);
            Assert.That(orderId, Is.EqualTo(order.OrderId));
        }
    }
}
