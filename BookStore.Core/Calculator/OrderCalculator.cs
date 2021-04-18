using BookStore.Core.Domain;
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

        public decimal CalculateOrderTotal(decimal tax = 0, IDiscount discount = null)
        {
            var total = (discount != null ? discount.Apply(_order) : _order)
                .Books.Sum(b => b.TotalCost);

            return total + (total * tax);
        }
    }
}