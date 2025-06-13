using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransActiva.Application.DTOs;
using TransActiva.Application.Features.Pagos.Queries.GetPedidosByUserId;

namespace TransActiva.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PedidosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("usuario/{userId}")]
    public async Task<ActionResult<List<PedidoDto>>> GetByUserId(int userId)
    {
        var result = await _mediator.Send(new GetPedidosByUserIdQuery(userId));
        return Ok(result);
    }
}