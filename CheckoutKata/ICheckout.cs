﻿namespace CheckoutKata
{
    interface ICheckout
    {
        void Scan(string item);
        void Finish();
    }
}