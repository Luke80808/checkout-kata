using checkout_kata.Classes;
using checkout_kata.Interfaces;

namespace checkout_kata.Implementation;

public class Checkout : ICheckout
{
    private readonly PricingRule[] _pricingRules;
    private readonly List<string> _items;

    public Checkout(IEnumerable<PricingRule> pricingRules)
    {
        _pricingRules = pricingRules.ToArray();
        _items = [];
    }

    public void Scan(string item)
    {
        _items.Add(item);
    }

    public decimal GetTotalPrice()
    {
        decimal total = 0m; // Decimal should always be used for monetary values
        var itemGroups = _items.GroupBy(i => i); // Group items by product type to allow rules to be applied on all of them at once

        foreach (var group in itemGroups)
        {
            var rules = _pricingRules
                .Where(r => r.Item == group.Key)
                .OrderByDescending(r => r.Count); // Orders by largest amount of items first to allow discount rules to be applied first

            var itemCount = group.Count();

            while (itemCount > 0)
            {
                var ruleToApply = rules.First(r => r.Count <= itemCount);
                total += ruleToApply.Price;
                itemCount -= ruleToApply.Count;
            }
        }

        return total;
    }
}
