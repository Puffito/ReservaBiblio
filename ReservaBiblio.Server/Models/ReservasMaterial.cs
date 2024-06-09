using System;
using System.Collections.Generic;

namespace ReservaBiblio.Server.Models;

public partial class ReservasMaterial
{
    public int Id { get; set; }

    public int ProfesorId { get; set; }

    public int MaterialId { get; set; }

    public DateOnly Dia { get; set; }

    public int HoraInicio { get; set; }

    public int HoraFin { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual Profesores Profesor { get; set; } = null!;
}
