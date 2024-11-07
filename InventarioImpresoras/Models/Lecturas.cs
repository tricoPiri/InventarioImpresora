namespace InventarioImpresoras.Models
{
    public class Lecturas
    {
        public int IdLectura { get; set; }
        public DateTime FechaLectura { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Observaciones {  get; set; }
        public int NumeroCopias { get; set; }
        public List<Impresoras> Impresoras { get; set; }
    }
}
