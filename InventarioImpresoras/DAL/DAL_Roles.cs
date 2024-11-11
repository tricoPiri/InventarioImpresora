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
    }
}
