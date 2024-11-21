using System.Data.SqlClient;
using System.Data;
using InventarioImpresoras.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlTypes;


namespace InventarioImpresoras.DAL
{
    public class DAL_Usuarios
    {
        DAL_Conexion objConexion = new DAL_Conexion();

        public DAL_Usuarios() 
        {
            objConexion.Conectar();
        }
        public List<Usuarios> getUsuarios()
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
                        },
                        Activo = (bool)(dr["activo"])
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return listaUsuarios;
        }
        public List<Usuarios> getUsuario(int idUsuario)
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("spObtenerUsuario", objConexion.conexion);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                

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
                        Password = (dr["password"].ToString() == "" ? "" : (string)dr["password"]),
                        Roles = new List<Roles>
                        {
                            new Roles()
                            {
                                IdRol = (int) (dr["idRol"]),
                                //Rol = (dr["rol"].ToString() == "" ? "" : (string)dr["rol"])

                            }
                        },
                        Activo = (bool)(dr["activo"])
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return listaUsuarios;
        }
        public decimal registrar(string nombre, string apellidoPaterno, string apellidoMaterno, string usuario, string password, int idRol)
        {
            decimal resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spInsertarUsuarios", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@nombres", nombre);
                sqlCmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                sqlCmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                sqlCmd.Parameters.AddWithValue("@usuario", usuario);
                sqlCmd.Parameters.AddWithValue("@password", password);
                sqlCmd.Parameters.AddWithValue("@idRol", idRol);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();

                objConexion.conexion.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    resultado = (decimal)(dr["idUsuario"]);
                }
                objConexion.conexion.Close();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return resultado;
        }

        public int editar(int idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, string usuario, string password, int idRol)
        {
            int resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spEditarUsuario", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                sqlCmd.Parameters.AddWithValue("@nombre", nombre);
                sqlCmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                sqlCmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                sqlCmd.Parameters.AddWithValue("@usuario", usuario);
                sqlCmd.Parameters.AddWithValue("@password", password);
                sqlCmd.Parameters.AddWithValue("@idRol", idRol);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();

                objConexion.conexion.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    resultado = (int)(dr["resultado"]);
                }
                objConexion.conexion.Close();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return resultado;
        }

        public int desactivar(int idUsuario)
        {
            int resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spDesactivarUsuario", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();

                objConexion.conexion.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    resultado = (int)(dr["resultado"]);
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
