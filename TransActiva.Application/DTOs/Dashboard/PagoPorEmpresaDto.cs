namespace TransActiva.Application.DTOs.Dashboard;

public class PagoPorEmpresaDto
{
    public string Ruc { get; set; } = string.Empty;
    public decimal TotalPagado { get; set; }
}