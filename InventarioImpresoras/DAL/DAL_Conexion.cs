using System.Data.SqlClient;

namespace InventarioImpresoras.DAL
{
    public class DAL_Conexion
	{
        public SqlConnection conexion;
        public void Conectar()
        {
            try
            {
                conexion = new SqlConnection("Server=DRAGONASUS\\SQLEXPRESS; Database=InventarioImpresoras;Integrated Security=true;");
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }

        }
    }
}
