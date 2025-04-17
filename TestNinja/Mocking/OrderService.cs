using System;

namespace TestNinja.Mocking
{
    public class OrderService
    {
        private readonly IStorage _storage;

        public OrderService(IStorage storage)
        {
            _storage = storage;
        }

        public Guid PlaceOrder(Order order)
        {
            var result = _storage.Store(order);
            if (result) return order.OrderId;
            // Some other work

            else return order.OrderId;
        }
    }

    public class Order
    {
        public Guid OrderId { get; set; }
    }

    public interface IStorage
    {
        bool Store(object obj);
    }
}