using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransActiva.Application.DTOs;
using TransActiva.Application.Features.Pagos.Queries.GetAllPagos;

namespace TransActiva.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PagosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<PagoDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllPagosQuery());
        return Ok(result);
    }
}