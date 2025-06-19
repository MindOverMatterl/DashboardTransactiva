namespace TransActiva.Application.DTOs.Dashboard
{
    public class TiempoEntregaDto
    {
        public string Producto { get; set; } = string.Empty;
        public int DiasDeDiferencia { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaLlegadaAcordada { get; set; }
    }
}