namespace Facturacion.DTO
{
    public class UsuarioSession
    {
        public string Nombre { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
    }

    public class UsuarioResponse
    {
        public int UsuarioId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        //public string Contrasena { get; set; } = null!;

        public int? EstadoId { get; set; }

        //public virtual Estado? Estado { get; set; }
    }

    //public class EstadoResponse
    //{
    //    public int EstadoId { get; set; }
    //    public string Nombre { get; set; } = null!;
    //}
}
