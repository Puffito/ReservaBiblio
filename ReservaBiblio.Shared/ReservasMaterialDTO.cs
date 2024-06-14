namespace ReservaBiblio.Shared
{
    public class ReservasMaterialDTO
    {
        public int Id { get; set; }

        public int ProfesorId { get; set; }

        public int MaterialId { get; set; }

        public DateOnly Dia { get; set; }

        public int HoraInicio { get; set; }

        public int HoraFin { get; set; }

        public virtual MaterialDTO Material { get; set; } = null!;

        public virtual ProfesoresDTO Profesor { get; set; } = null!;
    }
}
