using MediatR;
using TransActiva.Application.DTOs;
using TransActiva.Application.Features.Users.Commands;
using TransActiva.Application.Interfaces;
using TransActiva.Domain.Entities;

namespace TransActiva.Application.Features.Users.Handlers
{
    public class BulkCreateUsersCommandHandler : IRequestHandler<BulkCreateUsersCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BulkCreateUsersCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(BulkCreateUsersCommand request, CancellationToken cancellationToken)
        {
            foreach (var user in request.Users)
            {
                var existing = await _unitOfWork.Users.GetByEmailAsync(user.Email);
                if (existing != null) continue; // Puedes loguear o acumular errores si deseas

                var nuevoUsuario = new User
                {
                    Email = user.Email,
                    Password = user.Password,
                    UserTypeId = user.UserTypeId,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.Users.AddAsync(nuevoUsuario);
            }

            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}