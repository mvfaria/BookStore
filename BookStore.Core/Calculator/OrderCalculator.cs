using System.Linq;

namespace BookStore.Core.Calculator
{
    public class OrderCalculator
    {
        private readonly Order _order;

        public OrderCalculator(Order order)
        {
            _order = order;
        }

        public decimal CalculateOrderTotal()
        {
            return _order.Books.Sum(b => b.TotalCost);
        }
    }
}