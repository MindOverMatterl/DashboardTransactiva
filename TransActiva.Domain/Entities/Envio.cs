namespace TransActiva.Domain.Entities
{
    public class Envio
    {
        public int Id { get; set; }
        public string? Estado { get; set; }
        public string NombreEmpresa { get; set; } = null!;
        public string RucEmpresa { get; set; } = null!;
        public string Asesor { get; set; } = null!;
        public string NumeroTelefonico { get; set; } = null!;
        public string DireccionEnvio { get; set; } = null!;
        public string DireccionRecojo { get; set; } = null!;
        public DateTime FechaLlegada { get; set; }
        public string NroGuia { get; set; } = null!;
    }
}
