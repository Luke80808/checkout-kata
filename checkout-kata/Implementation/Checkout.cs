using checkout_kata.Interfaces;

namespace checkout_kata.Implementation;

public class Checkout : ICheckout
{
    public void Scan(string item)
    {
        throw new NotImplementedException();
    }

    public int GetTotalPrice()
    {
        throw new NotImplementedException();
    }
}
