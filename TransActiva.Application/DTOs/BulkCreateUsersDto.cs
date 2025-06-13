namespace TransActiva.Application.DTOs
{
    public class BulkCreateUsersDto
    {
        public List<CreateUserDto> Users { get; set; } = new();
    }
}