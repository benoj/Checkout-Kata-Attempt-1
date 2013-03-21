namespace CheckoutKata
{
    class Basket
    {
        private readonly DiscountCalculator _discountCalculator;
        private readonly TotalCalculator _totalCalculator;


        public Basket(DiscountCalculator discountCalculator, TotalCalculator totalCalculator)
        {
            _discountCalculator = discountCalculator;
            _totalCalculator = totalCalculator;
        }


        public void Add(string item)
        {
            _totalCalculator.Add(item);
            _discountCalculator.Add(item);
       
        }

        public void Finished()
        {
            _discountCalculator.ApplyDiscount();   
        }
    }
}