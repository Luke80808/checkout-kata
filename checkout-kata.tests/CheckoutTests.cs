using checkout_kata.Classes;
using checkout_kata.Implementation;

namespace checkout_kata.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyBasket_Returns0()
        {
            // Arrange
            var checkout = new Checkout(new List<PricingRule>());

            // Act
            var total = checkout.GetTotalPrice();

            // Assert
            Assert.That(total, Is.EqualTo(0));
        }
    }
}