using System.Linq;

namespace BookStore.Core.Domain
{
    public class CategoryCrimeDiscount : IDiscount
    {
        private const decimal _discount = 0.03m;

        public Order Apply(Order order) => new Order
        {
            Books = order.Books.Select(b => new Book
            {
                BookName = b.BookName,
                Category = b.Category,
                TotalCost = (b.Category == BookCategory.Crime) ? b.TotalCost - (b.TotalCost * _discount) : b.TotalCost
            }).ToList()
        };
    }
}
