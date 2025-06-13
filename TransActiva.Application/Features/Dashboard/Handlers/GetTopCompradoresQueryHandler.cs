using MediatR;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers;

public class GetTopCompradoresQueryHandler 
    : IRequestHandler<GetTopCompradoresQuery, List<TopCompradorDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTopCompradoresQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TopCompradorDto>> Handle(GetTopCompradoresQuery request, CancellationToken cancellationToken)
    {
        var pedidos = await _unitOfWork.Pedidos.GetAllAsync();
        var usuarios = await _unitOfWork.Users.GetAllAsync();

        var resultado = pedidos
            .Where(p => p.IdComprador > 0)
            .GroupBy(p => p.IdComprador)
            .Select(g =>
            {
                var user = usuarios.FirstOrDefault(u => u.Id == g.Key);
                return new TopCompradorDto
                {
                    Email = user?.Email ?? "Desconocido",
                    CantidadPedidos = g.Count()
                };
            })
            .OrderByDescending(x => x.CantidadPedidos)
            .Take(5)
            .ToList();

        return resultado;
    }
}