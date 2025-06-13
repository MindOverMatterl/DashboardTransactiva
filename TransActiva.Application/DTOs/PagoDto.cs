namespace TransActiva.Application.DTOs;

public class PagoDto
{
    public int Id { get; set; }
    public decimal Monto { get; set; }
    public DateTime FechaPago { get; set; }
    public string Metodo { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}