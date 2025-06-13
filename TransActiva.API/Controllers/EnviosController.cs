using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransActiva.Application.DTOs;

using TransActiva.Application.Features.Users.Queries.GetAllEnvios;

namespace TransActiva.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnviosController : ControllerBase
{
    private readonly IMediator _mediator;

    public EnviosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<EnvioDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEnviosQuery());
        return Ok(result);
    }
}