using InventarioImpresoras.Models;
using System.Data.SqlClient;
using System.Data;

namespace InventarioImpresoras.DAL
{
    public class DAL_Roles
    {
        DAL_Conexion objConexion = new DAL_Conexion();

        public DAL_Roles() 
        {
            objConexion.Conectar();
        }

        public List<Roles> getRoles()
        {
            List<Roles> listaRoles = new List<Roles>();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("spObtenerRoles", objConexion.conexion);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd);
                DataTable dataTable = new DataTable();
                objConexion.conexion.Open();
                dataAdapter.Fill(dataTable);
                objConexion.conexion.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    listaRoles.Add(new Roles
                    {
                        IdRol = (int)dr["idRol"],
                        Rol = (dr["nombre"].ToString() == "" ? "" : (string)dr["nombre"])
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return listaRoles;
        }

        public decimal registrar(string nombre)
        {
            decimal resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spInsertarRoles", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@nombre", nombre);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();

                objConexion.conexion.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    resultado = (decimal)(dr["idRol"]);
                }
                objConexion.conexion.Close();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return resultado;
        }
    }
}
