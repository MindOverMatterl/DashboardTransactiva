public class PedidoDto
{
    public int Id { get; set; }
    public int IdProveedor { get; set; }
    public int IdComprador { get; set; }
    public int IdPedidosProductos { get; set; }
    public string Estado { get; set; } = string.Empty;
}