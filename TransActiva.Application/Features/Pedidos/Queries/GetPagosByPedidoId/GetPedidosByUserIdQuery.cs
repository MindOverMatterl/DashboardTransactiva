using MediatR;
using TransActiva.Application.DTOs;

namespace TransActiva.Application.Features.Pagos.Queries.GetPedidosByUserId;

public record GetPedidosByUserIdQuery(int UserId) : IRequest<List<PedidoDto>>;
