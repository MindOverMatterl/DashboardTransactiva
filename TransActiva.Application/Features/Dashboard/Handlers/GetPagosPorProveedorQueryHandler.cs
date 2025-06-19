using MediatR;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers;

public class GetPagosPorProveedorQueryHandler 
    : IRequestHandler<GetPagosPorProveedorQuery, List<PagosPorProveedorDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPagosPorProveedorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PagosPorProveedorDto>> Handle(GetPagosPorProveedorQuery request, CancellationToken cancellationToken)
    {
        var pedidos = await _unitOfWork.Pedidos.GetAllAsync();
        var users = await _unitOfWork.Users.GetAllAsync();
        var perfiles = await _unitOfWork.UserProfiles.GetAllAsync();
        var productos = await _unitOfWork.PedidoProductos.GetAllAsync();
        var pagos = await _unitOfWork.Pagos.GetAllAsync();

        var resultado = (
                from pe in pedidos
                join u in users on pe.IdProveedor equals u.Id
                join up in perfiles on u.Id equals up.UserId
                join pp in productos on pe.IdPedidosProductos equals pp.Id
                join p in pagos on pp.IdPago equals p.Id
                group p by up.Name into g
                select new PagosPorProveedorDto
                {
                    Proveedor = g.Key ?? "Sin nombre",
                    Total = g.Sum(x => x.Monto)
                }
            )
            .OrderByDescending(x => x.Total)
            .ToList();

        return resultado;
    }
}