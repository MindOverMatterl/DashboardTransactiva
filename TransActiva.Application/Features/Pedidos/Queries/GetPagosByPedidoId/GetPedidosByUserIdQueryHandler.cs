using MediatR;
using TransActiva.Application.DTOs;
using TransActiva.Application.Interfaces;
using DomainPedido = TransActiva.Domain.Entities.Pedido;

namespace TransActiva.Application.Features.Pagos.Queries.GetPedidosByUserId;

public class GetPedidosByUserIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetPedidosByUserIdQuery, List<PedidoDto>>
{
    public async Task<List<PedidoDto>> Handle(GetPedidosByUserIdQuery request, CancellationToken cancellationToken)
    {
        var pedidos = await unitOfWork.Pedidos.GetByUserIdAsync(request.UserId);

        return pedidos.Select(p => new PedidoDto
        {
            Id = p.Id,
            Estado = p.Estado ?? string.Empty,
            IdProveedor = p.IdProveedor,
            IdComprador = p.IdComprador,
            IdPedidosProductos = p.IdPedidosProductos
        }).ToList();
    }
}