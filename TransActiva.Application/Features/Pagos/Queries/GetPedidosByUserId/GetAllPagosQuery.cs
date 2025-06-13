using MediatR;
using TransActiva.Application.DTOs;

namespace TransActiva.Application.Features.Pagos.Queries.GetAllPagos;

public record GetAllPagosQuery() : IRequest<List<PagoDto>>;