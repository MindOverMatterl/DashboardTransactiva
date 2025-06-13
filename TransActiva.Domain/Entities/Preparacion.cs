namespace TransActiva.Domain.Entities
{
    public class Preparacion
    {
        public int Id { get; set; }
        public string? Estado { get; set; }
        public string ComoEnvia { get; set; } = null!;
        public string Detalles { get; set; } = null!;
        public int? IdEnvio { get; set; }
    }
}