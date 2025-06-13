using MediatR;
using TransActiva.Application.DTOs;

namespace TransActiva.Application.Features.Users.Commands
{
    public class BulkCreateUsersCommand : IRequest<Unit>
    {
        public List<CreateUserDto> Users { get; set; } = new();
    }
}