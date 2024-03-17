namespace checkout_kata.Classes;

public class PricingRule(string item, int count, decimal price)
{
    public readonly string Item = item;
    public readonly int Count = count;
    public readonly decimal Price = price;
}
