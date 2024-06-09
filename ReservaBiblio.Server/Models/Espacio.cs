﻿using System;
using System.Collections.Generic;

namespace ReservaBiblio.Server.Models;

public partial class Espacio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<ReservasEspacios> ReservasEspacios { get; set; } = new List<ReservasEspacios>();
}
