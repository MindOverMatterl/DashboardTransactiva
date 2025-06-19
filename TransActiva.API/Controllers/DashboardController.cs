using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransActiva.Application.Features.Dashboard.Queries;

namespace TransActiva.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("usertypes")]
    public async Task<IActionResult> GetUserTypes()
    {
        var result = await _mediator.Send(new GetUserTypeDistributionQuery());
        return Ok(result);
    }

    [HttpGet("payments/monthly")]
    public async Task<IActionResult> GetMonthlyPayments()
    {
        var result = await _mediator.Send(new GetMonthlyPaymentsQuery());
        return Ok(result);
    }

    [HttpGet("pedidos/estado")]
    public async Task<IActionResult> GetPedidosPorEstado()
    {
        var result = await _mediator.Send(new GetPedidosPorEstadoQuery());
        return Ok(result);
    }

    [HttpGet("productos/top")]
    public async Task<IActionResult> GetTopProductos()
    {
        var result = await _mediator.Send(new GetTopProductosQuery());
        return Ok(result);
    }

    [HttpGet("envios/estado")]
    public async Task<IActionResult> GetEnviosPorEstado()
    {
        var result = await _mediator.Send(new GetEnviosPorEstadoQuery());
        return Ok(result);
    }

    [HttpGet("compradores/top")]
    public async Task<IActionResult> GetTopCompradores()
    {
        var result = await _mediator.Send(new GetTopCompradoresQuery());
        return Ok(result);
    }

    [HttpGet("pagos/empresa")]
    public async Task<IActionResult> GetPagosPorEmpresa()
    {
        var result = await _mediator.Send(new GetPagosPorEmpresaQuery());
        return Ok(result);
    }

    [HttpGet("pagos/estado")]
    public async Task<IActionResult> GetPagosPorEstado()
    {
        var result = await _mediator.Send(new GetPagosPorEstadoQuery());
        return Ok(result);
    }
    [HttpGet("pagos/por-dia")]
    public async Task<IActionResult> GetPagosPorDia()
    {
        var result = await _mediator.Send(new GetPagosPorDiaQuery());
        return Ok(result);
    }
    [HttpGet("pagos-por-proveedor")]
    public async Task<ActionResult<List<PagosPorProveedorDto>>> GetPagosPorProveedor()
    {
        var resultado = await _mediator.Send(new GetPagosPorProveedorQuery());
        return Ok(resultado);
    }
    [HttpGet("tiempo-entrega")]
    public async Task<IActionResult> GetTiempoEntrega()
    {
        var resultado = await _mediator.Send(new GetTiempoEntregaQuery());
        return Ok(resultado);
    }
    
}