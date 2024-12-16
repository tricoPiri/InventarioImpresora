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
                //conexion = new SqlConnection("Server=DRAGONASUS\\SQLEXPRESS; Database=InventarioImpresoras;Integrated Security=true;");
                //conexion = new SqlConnection("Server=DESKTOP-KU8S138\\SQLEXPRESS; Database=InventarioImpresoras;Integrated Security=true;");
                conexion = new SqlConnection("Server=CTI01GM24\\SQLEXPRESS01; Database=InventarioImpresoras;Integrated Security=true;");
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }

        }
    }
}
