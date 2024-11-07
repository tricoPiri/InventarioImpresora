using System.Data.SqlClient;
using System.Data;
//using Serilog;
using InventarioImpresoras.Models;

namespace InventarioImpresoras.DAL
{
    public class DAL_Login
    {
        DAL_Conexion objConexion = new DAL_Conexion();
        public DAL_Login()
        {
            objConexion.Conectar();
        }

        public List<Usuarios> Login(string usuario, string password)
        {
            List<Usuarios> listaLogin = new List<Usuarios>();
            try
            {
                SqlCommand command = new SqlCommand("spLogin", objConexion.conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@password", password);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                objConexion.conexion.Open();
                dataAdapter.Fill(dataTable);
                objConexion.conexion.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    listaLogin.Add(new Usuarios
                    {
                        Usuario = (string)dr["usuario"],
                        Roles = new List<Roles>
                        {
                            new Roles
                            {
                                IdRol = (int)dr["idRol"]
                            }
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }

            return listaLogin;
        }
	}
}
