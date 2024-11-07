namespace InventarioImpresoras.Models
{
    public class Impresoras
    {
        public int IdImpresora {  get; set; }   
        public string NumeroSerie { get; set; }
        public string Nombre {  get; set; } 
        public List<Marcas> Marcas { get; set; }   
        public List<Modelos> Modelos { get; set; }  
        public List<Areas> Areas { get; set; }
        public bool Activo { get; set; }
    }
}
