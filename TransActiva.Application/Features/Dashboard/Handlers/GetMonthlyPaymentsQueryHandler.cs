using MediatR;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers;

public class GetMonthlyPaymentsQueryHandler 
    : IRequestHandler<GetMonthlyPaymentsQuery, List<MonthlyPaymentDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMonthlyPaymentsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<MonthlyPaymentDto>> Handle(GetMonthlyPaymentsQuery request, CancellationToken cancellationToken)
    {
        var pagos = await _unitOfWork.Pagos.GetAllAsync();

        var resultado = pagos
            .Where(p => p.FechaPago != default) 
            .GroupBy(p => p.FechaPago.ToString("yyyy-MM"))
            .Select(g => new MonthlyPaymentDto
            {
                Mes = g.Key,
                TotalPagado = g.Sum(p => p.Monto)
            })
            .OrderBy(r => r.Mes)
            .ToList();

        return resultado;
    }
}