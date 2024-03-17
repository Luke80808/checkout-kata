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

        [Test]
        public void Basket_Calculates_SingleRule()
        {
            // Arrange
            var rules = new List<PricingRule>()
            {
                new PricingRule("A", 1, 50)
            };
            var checkout = new Checkout(rules);

            // Act
            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            // Assert
            Assert.That(total, Is.EqualTo(50));
        }

        [Test]
        public void Basket_Calculates_MultipleRules_SameProduct_OneRuleApplied()
        {
            // Arrange
            var rules = new List<PricingRule>()
            {
                new PricingRule("A", 1, 50),
                new PricingRule("A", 3, 130)
            };
            var checkout = new Checkout(rules);

            // Act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            // Assert
            Assert.That(total, Is.EqualTo(130));
        }
    }
}