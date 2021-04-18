namespace BookStore.Core.Domain
{
    public class Book
    {
        public string BookName { get; set; }
        public BookCategory Category { get; set; }
        public decimal TotalCost { get; set; }
    }
}