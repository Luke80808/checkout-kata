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

    public decimal GetTotalPrice()
    {
        decimal total = 0m;
        var itemsGroups = _items.GroupBy(x => x);

        foreach (var @group in itemsGroups)
        {
            var rules = _pricingRules
                .Where(r => r.Item == @group.Key)
                .OrderByDescending(r => r.Count);
            var itemCount = @group.Count();

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
