namespace BackEnd.DTO.CustomerDTO
{
    public class UserResponseDto
    {
        public List<ReadUserDto> customerDtos { get; set; } = new List<ReadUserDto>();
        public int Pages { get; set; }
        public int CurrentPages { get; set; }
    }
}
