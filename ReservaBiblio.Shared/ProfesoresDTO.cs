using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaBiblio.Shared
{
    public class ProfesoresDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Departamento { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public string RangoAdministrador { get; set; } = null!;

        public virtual ICollection<ReservasEspaciosDTO> ReservasEspacios { get; set; } = new List<ReservasEspaciosDTO>();

        public virtual ICollection<ReservasMaterialDTO> ReservasMaterials { get; set; } = new List<ReservasMaterialDTO>();
    }
}
