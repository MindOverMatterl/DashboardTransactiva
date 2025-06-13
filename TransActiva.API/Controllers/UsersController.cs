using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransActiva.Application.DTOs;
using TransActiva.Application.Features.Users.Commands.CreateUser;
using TransActiva.Application.Features.Users.Commands;
using TransActiva.Application.Features.Users.Queries.GetAllUsers;
using TransActiva.Application.Features.Users.Queries.GetUserById;

namespace TransActiva.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
    {
        var id = await _mediator.Send(new CreateUserCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> BulkCreate([FromBody] BulkCreateUsersCommand command)
    {
        await _mediator.Send(command);
        return Ok("Usuarios creados exitosamente");
    }
}