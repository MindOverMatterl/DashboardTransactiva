using MediatR;
using TransActiva.Application.DTOs;
using TransActiva.Application.Features.Users.Queries.GetAllEnvios;
using TransActiva.Application.Interfaces;

public class GetAllEnviosQueryHandler : IRequestHandler<GetAllEnviosQuery, List<EnvioDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEnviosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<EnvioDto>> Handle(GetAllEnviosQuery request, CancellationToken cancellationToken)
    {
        var envios = await _unitOfWork.Envios.GetAllAsync();

        return envios.Select(e => new EnvioDto
        {
            Id = e.Id,
            NombreEmpresa = e.NombreEmpresa,
            Estado = e.Estado ?? string.Empty,
            FechaLlegada = e.FechaLlegada
        }).ToList();
    }
}