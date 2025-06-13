namespace TransActiva.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }           // ✅ ya no nullable
        public int IdComprador { get; set; }           // ✅ ya no nullable
        public int IdPedidosProductos { get; set; }    // ✅ ya no nullable
        public string Estado { get; set; } = string.Empty; 
    }
}