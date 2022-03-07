namespace BackEnd.DTO.ProductDTO
{
    public class ProductResponseDto
    {
        public List<ReadProductDto> Products { get; set; } = new List<ReadProductDto>();
        public int Pages { get; set; }
        public int CurrentPages { get; set; }
    }
}
