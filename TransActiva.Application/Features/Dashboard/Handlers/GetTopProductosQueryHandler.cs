using MediatR;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers;

public class GetTopProductosQueryHandler 
    : IRequestHandler<GetTopProductosQuery, List<TopProductoDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTopProductosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TopProductoDto>> Handle(GetTopProductosQuery request, CancellationToken cancellationToken)
    {
        var productos = await _unitOfWork.PedidoProductos.GetAllAsync();

        var resultado = productos
            .GroupBy(p => p.Producto)
            .Select(g => new TopProductoDto
            {
                Producto = g.Key ?? "Sin nombre",
                CantidadPedidos = g.Count()
            })
            .OrderByDescending(r => r.CantidadPedidos)
            .Take(5)
            .ToList();

        return resultado;
    }
}