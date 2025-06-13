using MediatR;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers;

public class GetPagosPorEmpresaQueryHandler 
    : IRequestHandler<GetPagosPorEmpresaQuery, List<PagoPorEmpresaDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPagosPorEmpresaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PagoPorEmpresaDto>> Handle(GetPagosPorEmpresaQuery request, CancellationToken cancellationToken)
    {
        var pagos = await _unitOfWork.Pagos.GetAllAsync();
        var productos = await _unitOfWork.PedidoProductos.GetAllAsync();
        var pedidos = await _unitOfWork.Pedidos.GetAllAsync();
        var usuarios = await _unitOfWork.Users.GetAllAsync();
        var perfiles = await _unitOfWork.UserProfiles.GetAllAsync();

        var joined = from producto in productos
            where producto.IdPago > 0
            join pago in pagos on producto.IdPago equals pago.Id
            join pedido in pedidos on producto.Id equals pedido.IdPedidosProductos
            join user in usuarios on pedido.IdComprador equals user.Id
            join perfil in perfiles on user.Id equals perfil.UserId
            group pago by perfil.Ruc into g
            select new PagoPorEmpresaDto
            {
                Ruc = g.Key ?? "Sin RUC",
                TotalPagado = g.Sum(p => p.Monto)
            };

        return joined.OrderByDescending(p => p.TotalPagado).ToList();
    }
}