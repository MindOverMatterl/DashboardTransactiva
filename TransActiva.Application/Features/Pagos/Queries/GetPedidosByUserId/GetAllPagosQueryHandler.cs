using MediatR;
using TransActiva.Application.DTOs;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Pagos.Queries.GetAllPagos;

public class GetAllPagosQueryHandler : IRequestHandler<GetAllPagosQuery, List<PagoDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPagosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PagoDto>> Handle(GetAllPagosQuery request, CancellationToken cancellationToken)
    {
        var pagos = await _unitOfWork.Pagos.GetAllAsync();

        return pagos.Select(p => new PagoDto
        {
            Id = p.Id,
            Monto = p.Monto,
            FechaPago = p.FechaPago,
            Estado = p.Estado
        }).ToList();
    }
}