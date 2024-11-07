namespace InventarioImpresoras.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Usuario {  get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public List<Roles> Roles { get; set; }
    }
}
