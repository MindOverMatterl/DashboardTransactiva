using System;
using System.Collections.Generic;

namespace TransActiva.Infrastructure.Persistence.Entities;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdComprador { get; set; }

    public int? IdPedidosProductos { get; set; }

    public string? Estado { get; set; }

    public virtual User? IdCompradorNavigation { get; set; }

    public virtual Pedidosproducto? IdPedidosProductosNavigation { get; set; }

    public virtual User? IdProveedorNavigation { get; set; }
}
