namespace TransActiva.Application.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public int UserTypeId { get; set; }
    public DateTime CreatedAt { get; set; }
}