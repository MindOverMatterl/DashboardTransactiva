using MediatR;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers
{
    public class GetTiempoEntregaQueryHandler : IRequestHandler<GetTiempoEntregaQuery, List<TiempoEntregaDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTiempoEntregaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TiempoEntregaDto>> Handle(GetTiempoEntregaQuery request, CancellationToken cancellationToken)
        {
            var productos = await _unitOfWork.PedidoProductos.GetAllAsync();
            var pagos = await _unitOfWork.Pagos.GetAllAsync();

            var resultado = (from pp in productos
                join p in pagos on pp.IdPago equals p.Id
                where true
                select new TiempoEntregaDto
                {
                    Producto = pp.Producto,
                    DiasDeDiferencia = (pp.FechaLlegadaAcordada - p.FechaPago).Days,
                    FechaPago = p.FechaPago,
                    FechaLlegadaAcordada = pp.FechaLlegadaAcordada
                }).ToList();

            return resultado;
        }
    }
}