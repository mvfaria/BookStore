namespace BookStore.Core.Domain
{
    public interface IDiscount
    {
        Order Apply(Order order);
    }
}
