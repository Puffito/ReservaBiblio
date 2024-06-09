using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaBiblio.Shared
{
    public class EspacioDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Clave { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string? Imagen { get; set; }

        public virtual ICollection<ReservasEspaciosDTO> ReservasEspacios { get; set; } = new List<ReservasEspaciosDTO>();
    }
}
