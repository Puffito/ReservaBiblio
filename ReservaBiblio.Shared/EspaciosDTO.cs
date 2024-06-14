namespace ReservaBiblio.Shared
{
    public class EspaciosDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Clave { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string? Imagen { get; set; }

    }
}
