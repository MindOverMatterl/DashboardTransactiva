using MediatR;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers;

public class GetPedidosPorEstadoQueryHandler 
    : IRequestHandler<GetPedidosPorEstadoQuery, List<PedidosPorEstadoDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPedidosPorEstadoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PedidosPorEstadoDto>> Handle(GetPedidosPorEstadoQuery request, CancellationToken cancellationToken)
    {
        var pedidos = await _unitOfWork.Pedidos.GetAllAsync();

        var resultado = pedidos
            .GroupBy(p => p.Estado)
            .Select(g => new PedidosPorEstadoDto
            {
                Estado = g.Key ?? "Sin estado",
                Cantidad = g.Count()
            })
            .OrderByDescending(r => r.Cantidad)
            .ToList();

        return resultado;
    }
}