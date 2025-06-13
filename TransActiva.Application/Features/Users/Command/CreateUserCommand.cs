using MediatR;
using TransActiva.Application.DTOs;

namespace TransActiva.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserDto User { get; set; }

        public CreateUserCommand(CreateUserDto user)
        {
            User = user;
        }
    }
}