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
            // Act
            Checkout sut = new Checkout(new List<PricingRule>());

            // Assert


            Assert.Pass();
        }
    }
}