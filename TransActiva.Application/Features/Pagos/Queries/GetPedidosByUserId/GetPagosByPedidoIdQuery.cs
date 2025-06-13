using MediatR;
using TransActiva.Application.DTOs;

namespace TransActiva.Application.Features.Pedidos.Queries.GetPagosByPedidoId;

public record GetPagosByPedidoIdQuery(int PedidoId) : IRequest<List<PagoDto>>;