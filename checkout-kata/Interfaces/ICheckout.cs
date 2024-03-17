﻿namespace checkout_kata.Interfaces;

public interface ICheckout
{
    void Scan(string item);
    decimal GetTotalPrice();
}
