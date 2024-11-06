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
                /*conexion = new SqlConnection("Server=172.16.9.15\\desarrollo;Integrated Security=false;Database=Administrativo;user id=sa;password=Abc@123;");*/

                //conexion = new SqlConnection("Server=172.168.1.136\\Desarrollo;Integrated Security=false;Database=Administrativo;user id=sa;password=Abc@123;");

                //conexion = new SqlConnection("Server=172.168.1.136\\Desarrollo;Integrated Security=false;Database=Rh&Adm;user id=sa;password=Abc@123;");

                conexion = new SqlConnection("Server=CTI01GM24\\SQLEXPRESS01; Database=InventarioImpresoras;Integrated Security=true;");

                //conexion = new SqlConnection("Server=172.16.9.15\\Desarrollo;Integrated Security=false;Database=Rh&Adm;user id=sa;password=Abc@123;");
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }

        }
    }
}
