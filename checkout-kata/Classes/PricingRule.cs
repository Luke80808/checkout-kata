
namespace checkout_kata.Classes;

public class PricingRule(char item, int count, decimal price)
{
    public readonly char Item = item;
    public readonly int Count = count;
    public readonly decimal Price = price;
}
