using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        Product _product;
        Customer _customer;

        [SetUp]
        public void SetUp()
        {
            _product = new Product() { ListPrice = 100 };
            _customer = new Customer();
        }
        [Test]
        public void GetPrice_WhenCustomerIsGold_ShouldReturnDiscountedPrice()
        {
            _customer.IsGold = true;
            Assert.That(_product.GetPrice(_customer), Is.EqualTo(70));
        }

        [Test]
        public void GetPrice_WhenCustomerIsNotGold_ShouldReturnPrice()
        {
            //_customer.IsGold = false;
            Assert.That(_product.GetPrice(_customer), Is.EqualTo(100));
        }
    }
}
