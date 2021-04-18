using System;
using System.Linq;

namespace BookStore.Core.Calculator
{
    public class OrderCalculator
    {
        private readonly Order _order;

        public OrderCalculator(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            _order = order;
        }

        public decimal CalculateOrderTotal(decimal tax = 1)
        {
            return _order.Books.Sum(b => b.TotalCost) * tax;
        }
    }
}