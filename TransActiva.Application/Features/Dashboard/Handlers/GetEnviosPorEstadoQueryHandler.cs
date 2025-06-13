using MediatR;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers;

public class GetEnviosPorEstadoQueryHandler 
    : IRequestHandler<GetEnviosPorEstadoQuery, List<EnviosPorEstadoDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEnviosPorEstadoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<EnviosPorEstadoDto>> Handle(GetEnviosPorEstadoQuery request, CancellationToken cancellationToken)
    {
        var envios = await _unitOfWork.Envios.GetAllAsync();

        var resultado = envios
            .GroupBy(e => e.Estado)
            .Select(g => new EnviosPorEstadoDto
            {
                Estado = g.Key ?? "Sin estado",
                Cantidad = g.Count()
            })
            .OrderByDescending(r => r.Cantidad)
            .ToList();

        return resultado;
    }
}