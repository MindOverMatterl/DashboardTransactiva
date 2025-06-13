using MediatR;
using TransActiva.Application.Interfaces;
using DomainUser = TransActiva.Domain.Entities.User;

namespace TransActiva.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWork.Users.GetByEmailAsync(request.User.Email);
            if (existingUser != null)
                throw new Exception("Ya existe un usuario con ese email.");
            var user = new DomainUser
            {
                Email = request.User.Email,
                Password = request.User.Password,
                CreatedAt = DateTime.UtcNow,
                UserTypeId = request.User.UserTypeId,
                FailedLoginAttempts = 0,
                LockoutUntil = null
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();

            return user.Id;
        }
    }
}