using System;
using System.Collections.Generic;

namespace ReservaBiblio.Server.Models;

public partial class ReservasEspacios
{
    public int Id { get; set; }

    public int ProfesorId { get; set; }

    public int EspacioId { get; set; }

    public DateOnly Dia { get; set; }

    public int HoraInicio { get; set; }

    public int HoraFin { get; set; }

    public virtual Espacio Espacio { get; set; } = null!;

    public virtual Profesores Profesor { get; set; } = null!;
}
