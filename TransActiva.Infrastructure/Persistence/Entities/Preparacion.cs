﻿using System;
using System.Collections.Generic;

namespace TransActiva.Infrastructure.Persistence.Entities;

public partial class Preparacion
{
    public int IdPreparacion { get; set; }

    public string? Estado { get; set; }

    public string ComoEnvia { get; set; } = null!;

    public string Detalles { get; set; } = null!;

    public int? IdEnvio { get; set; }

    public virtual Envio? IdEnvioNavigation { get; set; }

    public virtual ICollection<Pedidosproducto> Pedidosproductos { get; set; } = new List<Pedidosproducto>();
}
