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
        public void MultipleRules_SameProduct_OneRuleApplied()
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

        [Test]
        public void TwoRules_SameProduct_BothRulesApplied()
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
            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            // Assert
            Assert.That(total, Is.EqualTo(180));
        }

        [Test]
        public void SingleRule_MultipleProducts()
        {
            // Arrange
            var rules = new List<PricingRule>()
            {
                new PricingRule("A", 1, 50),
                new PricingRule("B", 1, 30)
            };
            var checkout = new Checkout(rules);

            // Act
            checkout.Scan("A");
            checkout.Scan("B");

            var total = checkout.GetTotalPrice();

            // Assert
            Assert.That(total, Is.EqualTo(80));
        }

        [Test]
        public void MultipleRules_MultipleProducts_OnlyOneRuleApplied()
        {
            // Arrange
            var rules = new List<PricingRule>()
            {
                new PricingRule("A", 1, 50),
                new PricingRule("A", 3, 130),
                new PricingRule("B", 1, 30),
                new PricingRule("B", 2, 45)
            };
            var checkout = new Checkout(rules);

            // Act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");

            var total = checkout.GetTotalPrice();

            // Assert
            Assert.That(total, Is.EqualTo(175));
        }

        [Test]
        public void MultipleRules_MultipleProducts_MultipleRulesApplied()
        {
            // Arrange
            var rules = new List<PricingRule>()
            {
                new PricingRule("A", 1, 50),
                new PricingRule("A", 3, 130),
                new PricingRule("B", 1, 30),
                new PricingRule("B", 2, 45)
            };
            var checkout = new Checkout(rules);

            // Act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");

            var total = checkout.GetTotalPrice();

            // Assert
            Assert.That(total, Is.EqualTo(255));
        }

        [Test]
        public void MultipleRules_FourProducts_AllRulesApplied()
        {
            // Arrange
            var rules = new List<PricingRule>()
            {
                new PricingRule("A", 1, 50),
                new PricingRule("A", 3, 130),
                new PricingRule("B", 1, 30),
                new PricingRule("B", 2, 45),
                new PricingRule("C", 1, 20),
                new PricingRule("D", 1, 15)
            };
            var checkout = new Checkout(rules);

            // Act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");

            var total = checkout.GetTotalPrice();

            // Assert
            Assert.That(total, Is.EqualTo(290));
        }
    }
}