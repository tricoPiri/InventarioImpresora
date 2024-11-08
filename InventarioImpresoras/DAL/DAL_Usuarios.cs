using System.Data.SqlClient;
using System.Data;
using InventarioImpresoras.Models;

namespace InventarioImpresoras.DAL
{
    public class DAL_Usuarios
    {
        DAL_Conexion objConexion = new DAL_Conexion();

        public DAL_Usuarios() 
        {
            objConexion.Conectar();
        }
        public List<Usuarios> getEmpleados()
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("spObtenerUsuarios", objConexion.conexion);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd);
                DataTable dataTable = new DataTable();
                objConexion.conexion.Open();
                dataAdapter.Fill(dataTable);
                objConexion.conexion.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    listaUsuarios.Add(new Usuarios
                    {
                        IdUsuario = (int)dr["idUsuario"],
                        Nombres = (dr["nombres"].ToString() == "" ? "" : (string)dr["nombres"]),
                        ApellidoPaterno = (dr["apellidoPaterno"].ToString() == "" ? "" : (string)dr["apellidoPaterno"]),
                        ApellidoMaterno = (dr["apellidoMaterno"].ToString() == "" ? "" : (string)dr["apellidoMaterno"]),
                        Usuario = (dr["usuario"].ToString() == "" ? "" : (string)dr["usuario"]),
                        Roles = new List<Roles> 
                        { 
                            new Roles()
                            {
                                IdRol = (int) (dr["idRol"]),
                                Rol = (dr["rol"].ToString() == "" ? "" : (string)dr["rol"])

                            }
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return listaUsuarios;
        }
    }
}
