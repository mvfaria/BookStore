using System.Collections.Generic;

namespace BookStore.Core.Domain
{
    public class Order
    {
        public List<Book> Books { get; set; }
    }
}