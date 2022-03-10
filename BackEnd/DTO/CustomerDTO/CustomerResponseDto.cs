namespace BackEnd.DTO.CustomerDTO
{
    public class CustomerResponseDto
    {
        public List<ReadCustomerDto> Products { get; set; } = new List<ReadCustomerDto>();
        public int Pages { get; set; }
        public int CurrentPages { get; set; }
    }
}
