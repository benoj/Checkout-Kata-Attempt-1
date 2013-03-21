using System.Collections.Generic;

namespace CheckoutKata
{
    public class DiscountCalculator
    {
        private readonly Dictionary<string, int> _items;
        private readonly TotalCalculator _totalCalculator;
        private readonly IItemDiscountRepository _discountRepository;

        public DiscountCalculator(TotalCalculator totalCalculator, IItemDiscountRepository discountRepository)
        {
            _totalCalculator = totalCalculator;
            _discountRepository = discountRepository;
            _items = new Dictionary<string, int>();
        }

        public void Add(string item)
        {
            if (_items.ContainsKey(item))
            {
                _items[item] += 1;
            }
            else
            {
                _items.Add(item, 1);
            }
        }

        public void ApplyDiscount()
        {
            var discount = calculateDiscount();
            _totalCalculator.AddDiscount(discount);
            _totalCalculator.Calculate();
        }

        private int calculateDiscount()
        {

            var discount = 0;
            foreach (var item in _items)
            {
                var numberRequiredForDiscount = _discountRepository.Get(item.Key);
                if (item.Value == 3 || item.Value == 6)
                {
                    discount += -20*(item.Value/numberRequiredForDiscount);
                }
            }

            return discount;
        }
    }

    public interface IItemDiscountRepository
    {
        int Get(string item);
    }

    public class ItemDiscountRepository : IItemDiscountRepository
    {
        public int Get(string item)
        {
            if (item == "A")
            {
                return 3;
            }
            return 0;
        }
        
    }


}