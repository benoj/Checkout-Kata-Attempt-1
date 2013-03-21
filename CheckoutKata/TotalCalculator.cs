namespace CheckoutKata
{
    public class TotalCalculator
    {
        private readonly IDisplay _display;
        private readonly IPriceListRepository _priceListRepository;
        private int _subTotal;

        public TotalCalculator(IDisplay display, IPriceListRepository priceListRepository)
        {
            _display = display;
            _priceListRepository = priceListRepository;

        }

        public void Add(string item)
        {
            _subTotal += _priceListRepository.Get(item); 
        }

        public void AddDiscount(int discount)
        {
            _subTotal += discount;
        }

        public void Calculate()
        {
            _display.Display(_subTotal);
        }
    }
}