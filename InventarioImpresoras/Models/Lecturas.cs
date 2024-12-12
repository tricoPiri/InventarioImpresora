namespace InventarioImpresoras.Models
{
    public class Lecturas
    {
        public int IdLectura { get; set; }
        public DateTime FechaLectura { get; set; }
        public int LecturaAnterior { get; set; }
        public int LecturaActual { get; set; }
        public string Observaciones {  get; set; }
        public int NumeroCopias { get; set; }
        public List<Impresoras> Impresoras { get; set; }
        public bool Activo { get; set; }
    }
}
