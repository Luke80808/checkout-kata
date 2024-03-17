using checkout_kata.Classes;
using checkout_kata.Interfaces;

namespace checkout_kata.Implementation;

public class Checkout : ICheckout
{
    private PricingRule[] _pricingRules;
    private List<string> _items;

    public Checkout(IEnumerable<PricingRule> pricingRules)
    {
        _pricingRules = pricingRules.ToArray();
        _items = [];
    }
    public void Scan(string item)
    {
        throw new NotImplementedException();
    }

    public int GetTotalPrice()
    {
        throw new NotImplementedException();
    }
}
