namespace CheckoutKata
{
    public class Checkout: ICheckout
    {
        private readonly Basket _basket;

        public Checkout(TotalCalculator totalCalculator, DiscountCalculator discountCalculator)
        {
            _basket = new Basket(discountCalculator, totalCalculator);
        }

        public void Scan(string item)
        {
            _basket.Add(item);       
        }

        public void Finish()
        {
            _basket.Finished();
        }
    }
}
