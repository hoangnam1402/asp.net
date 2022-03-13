namespace BackEnd.DTO.OrderDTO
{
    public class CreateOrderItemDto
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }
    }
}
