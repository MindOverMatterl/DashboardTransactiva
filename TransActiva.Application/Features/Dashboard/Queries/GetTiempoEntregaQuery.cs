using MediatR;
using TransActiva.Application.DTOs.Dashboard;

namespace TransActiva.Application.Features.Dashboard.Queries
{
    public class GetTiempoEntregaQuery : IRequest<List<TiempoEntregaDto>>
    {
    }
}