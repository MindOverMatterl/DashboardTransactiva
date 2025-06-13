using MediatR;
using TransActiva.Application.DTOs;
using TransActiva.Application.Features.Users.Queries.GetAllUsers;
using TransActiva.Application.Interfaces;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.Users.GetAllAsync();

        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Email = u.Email,
            UserTypeId = u.UserTypeId,
            CreatedAt = u.CreatedAt
        }).ToList();
    }
}