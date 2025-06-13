using MediatR;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers;

public class GetPagosPorEstadoQueryHandler 
    : IRequestHandler<GetPagosPorEstadoQuery, List<PagosPorEstadoDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPagosPorEstadoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PagosPorEstadoDto>> Handle(GetPagosPorEstadoQuery request, CancellationToken cancellationToken)
    {
        var pagos = await _unitOfWork.Pagos.GetAllAsync();

        var resultado = pagos
            .GroupBy(p => p.Estado)
            .Select(g => new PagosPorEstadoDto
            {
                Estado = g.Key ?? "Sin estado",
                Cantidad = g.Count()
            })
            .OrderByDescending(r => r.Cantidad)
            .ToList();

        return resultado;
    }
}