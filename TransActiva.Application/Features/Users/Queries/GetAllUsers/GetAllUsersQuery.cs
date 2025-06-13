using MediatR;
using TransActiva.Application.DTOs;

namespace TransActiva.Application.Features.Users.Queries.GetAllUsers;

public record GetAllUsersQuery() : IRequest<List<UserDto>>;