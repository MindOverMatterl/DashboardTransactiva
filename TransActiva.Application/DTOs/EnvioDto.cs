namespace TransActiva.Application.DTOs;

public class EnvioDto
{
    public int Id { get; set; }
    public string NombreEmpresa { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public DateTime FechaLlegada { get; set; }
}