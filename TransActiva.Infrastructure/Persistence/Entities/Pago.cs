using System;
using System.Collections.Generic;

namespace TransActiva.Infrastructure.Persistence.Entities;

public partial class Pago
{
    public int IdPago { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? Estado { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdBoleta { get; set; }

    public virtual Boleta? IdBoletaNavigation { get; set; }

    public virtual ICollection<Pedidosproducto> Pedidosproductos { get; set; } = new List<Pedidosproducto>();
}
