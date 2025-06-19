namespace TransActiva.Application.Dtos.Dashboard
{
    public class PagosPorDiaDto
    {
        public DateTime Fecha { get; set; }
        public decimal TotalPagado { get; set; }
        public int CantidadPagos { get; set; }
    }
}