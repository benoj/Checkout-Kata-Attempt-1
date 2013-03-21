using System.Collections.Generic;

namespace CheckoutKata
{
    public class PriceListRepository: IPriceListRepository
    {
        private static readonly IDictionary<string, int> PriceLookup = new Dictionary<string, int>
            {
                {"A",50},
                {"B",30},
                {"C",20},
                {"D",15}
            };

        public int Get(string itemName)
        {
            return PriceLookup[itemName];
        } 
    }

    public interface IPriceListRepository
    {
        int Get(string itemName);
    }

}