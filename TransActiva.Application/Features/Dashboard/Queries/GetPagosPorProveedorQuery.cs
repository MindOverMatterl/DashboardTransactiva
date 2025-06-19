using MediatR;
using TransActiva.Application.Dtos.Dashboard;
using System.Collections.Generic;

namespace TransActiva.Application.Features.Dashboard.Queries
{
    public class GetPagosPorProveedorQuery : IRequest<List<PagosPorProveedorDto>>
    {
    }
}