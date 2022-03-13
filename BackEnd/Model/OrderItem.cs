namespace BackEnd.Model
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }

        public int Price { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public ProductRating ProductRating { get; set; }
    }
}
