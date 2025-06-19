using MediatR;
using TransActiva.Application.Dtos.Dashboard;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers;

public class GetPagosPorDiaQueryHandler 
    : IRequestHandler<GetPagosPorDiaQuery, List<PagosPorDiaDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPagosPorDiaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PagosPorDiaDto>> Handle(GetPagosPorDiaQuery request, CancellationToken cancellationToken)
    {
        var pagos = await _unitOfWork.Pagos.GetAllAsync();

        var resultado = pagos
            .Where(p => p.FechaPago != default)
            .GroupBy(p => p.FechaPago.Date)
            .Select(g => new PagosPorDiaDto
            {
                Fecha = g.Key,
                TotalPagado = g.Sum(p => p.Monto),
                CantidadPagos = g.Count()
            })
            .OrderBy(r => r.Fecha)
            .ToList();

        return resultado;
    }
}