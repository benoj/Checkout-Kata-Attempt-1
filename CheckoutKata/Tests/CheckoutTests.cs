using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    class CheckoutTests : IDisplay
    {
        private int _totalRecieved;

        [Test]
        public void Given_item_a_is_scanned_Then_price_is_50()
        {
            var display = this;
            var totalCalculator = new TotalCalculator(display, new PriceListRepository());
            var checkout = new Checkout(totalCalculator, new DiscountCalculator(totalCalculator, new ItemDiscountRepository()));
            const string a = "A";
            checkout.Scan(a);
            checkout.Finish();
            Assert.That(_totalRecieved, Is.EqualTo(50));
        }

        [Test]
        public void Given_item_b_is_scanned_Then_price_is_30()
        {
            var display = this;
            var totalCalculator = new TotalCalculator(display, new PriceListRepository());
            var checkout = new Checkout(totalCalculator, new DiscountCalculator(totalCalculator, new ItemDiscountRepository()));
            const string item = "B";
            checkout.Scan(item);
            checkout.Finish();
            Assert.That(_totalRecieved, Is.EqualTo(30));
        }

        [Test]
        public void Given_item_c_is_scanned_Then_price_is_20()
        {
            var display = this;
            var totalCalculator = new TotalCalculator(display, new PriceListRepository());
            var checkout = new Checkout(totalCalculator, new DiscountCalculator(totalCalculator, new ItemDiscountRepository()));
            const string item = "C";
            checkout.Scan(item);
            checkout.Finish();
            Assert.That(_totalRecieved, Is.EqualTo(20));
        }

        [Test]
        public void Given_item_d_is_scanned_Then_price_is_15()
        {
            var display = this;
            var totalCalculator = new TotalCalculator(display, new PriceListRepository());
            var checkout = new Checkout(totalCalculator, new DiscountCalculator(totalCalculator, new ItemDiscountRepository()));
            const string item = "D";
            checkout.Scan(item);
            checkout.Finish();
            Assert.That(_totalRecieved, Is.EqualTo(15));
        }

        [Test]
        public void Given_A_and_B_items_are_scanned_Then_total_price_is_80()
        {
            var display = this;
            var totalCalculator = new TotalCalculator(display, new PriceListRepository());
            var checkout = new Checkout(totalCalculator, new DiscountCalculator(totalCalculator, new ItemDiscountRepository()));
            const string itemA = "A";
            const string itemB = "B";
            checkout.Scan(itemA);
            checkout.Scan(itemB);
            checkout.Finish();
            Assert.That(_totalRecieved, Is.EqualTo(80));
        }

        [Test]
        public void Given_two_As_are_scanned_Then_total_price_is_100()
        {
            var display = this;
            var totalCalculator = new TotalCalculator(display, new PriceListRepository());
            var checkout = new Checkout(totalCalculator, new DiscountCalculator(totalCalculator, new ItemDiscountRepository()));
            const string itemA = "A";
            checkout.Scan(itemA);
            checkout.Scan(itemA);
            checkout.Finish();
            Assert.That(_totalRecieved, Is.EqualTo(100));
        }

        [Test]
        public void Given_three_As_are_scanned_Then_total_price_is_130()
        {
            var display = this;
            var totalCalculator = new TotalCalculator(display, new PriceListRepository());
            var checkout = new Checkout(totalCalculator, new DiscountCalculator(totalCalculator, new ItemDiscountRepository()));
            const string itemA = "A";
            checkout.Scan(itemA);
            checkout.Scan(itemA);
            checkout.Scan(itemA);
            checkout.Finish();
            Assert.That(_totalRecieved, Is.EqualTo(130));
        }

        [Test]
        public void Given_six_As_are_scanned_Then_total_price_is_260()
        {
            var display = this;
            var totalCalculator = new TotalCalculator(display, new PriceListRepository());
            var checkout = new Checkout(totalCalculator, new DiscountCalculator(totalCalculator, new ItemDiscountRepository()));
            const string itemA = "A";
            checkout.Scan(itemA);
            checkout.Scan(itemA);
            checkout.Scan(itemA);
            checkout.Scan(itemA);
            checkout.Scan(itemA);
            checkout.Scan(itemA);
            checkout.Finish();
            Assert.That(_totalRecieved, Is.EqualTo(260));
        }

        public void Display(int total)
        {
            _totalRecieved = total;
        }
    }
}