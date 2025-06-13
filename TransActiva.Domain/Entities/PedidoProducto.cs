namespace TransActiva.Domain.Entities
{
    public class PedidoProducto
    {
        public int Id { get; set; }
        public string Producto { get; set; } = null!;
        public int Cantidad { get; set; }
        public string Descripcion { get; set; } = null!;
        public string DireccionEntrega { get; set; } = null!;
        public DateTime FechaLlegadaAcordada { get; set; }
        public DateTime FechaSolicitada { get; set; }
        public string NombreTransaccion { get; set; } = null!;
        public int? IdPago { get; set; }
        public int? IdPreparacion { get; set; }
    }
}