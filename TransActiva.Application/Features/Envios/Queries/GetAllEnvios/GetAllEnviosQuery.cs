using MediatR;
using TransActiva.Application.DTOs;

namespace TransActiva.Application.Features.Users.Queries.GetAllEnvios;

public record GetAllEnviosQuery() : IRequest<List<EnvioDto>>;