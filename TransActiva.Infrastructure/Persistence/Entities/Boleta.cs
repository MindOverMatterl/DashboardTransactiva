using System;
using System.Collections.Generic;

namespace TransActiva.Infrastructure.Persistence.Entities;

public partial class Boleta
{
    public int IdBoleta { get; set; }

    public string Ruta { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
