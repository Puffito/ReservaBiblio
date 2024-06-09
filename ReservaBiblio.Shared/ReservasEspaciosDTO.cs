using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaBiblio.Shared
{
    public class ReservasEspaciosDTO
    {
        public int Id { get; set; }

        public int ProfesorId { get; set; }

        public int EspacioId { get; set; }

        public DateOnly Dia { get; set; }

        public int HoraInicio { get; set; }

        public int HoraFin { get; set; }

        public virtual EspacioDTO Espacio { get; set; } = null!;

        public virtual ProfesoresDTO Profesor { get; set; } = null!;
    }
}
