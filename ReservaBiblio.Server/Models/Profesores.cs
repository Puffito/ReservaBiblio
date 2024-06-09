using System;
using System.Collections.Generic;

namespace ReservaBiblio.Server.Models;

public partial class Profesores
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Departamento { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string RangoAdministrador { get; set; } = null!;

    public virtual ICollection<ReservasEspacios> ReservasEspacios { get; set; } = new List<ReservasEspacios>();

    public virtual ICollection<ReservasMaterial> ReservasMaterials { get; set; } = new List<ReservasMaterial>();
}
