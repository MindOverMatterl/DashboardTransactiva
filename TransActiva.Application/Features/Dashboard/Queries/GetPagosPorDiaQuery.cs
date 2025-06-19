using MediatR;
using TransActiva.Application.Dtos.Dashboard;
using System.Collections.Generic;
using TransActiva.Application.DTOs;

namespace TransActiva.Application.Features.Dashboard.Queries
{
    public class GetPagosPorDiaQuery : IRequest<List<PagosPorDiaDto>>
    {
        
    }
}