using InventarioImpresoras.Models;
using System.Data.SqlClient;
using System.Data;

namespace InventarioImpresoras.DAL
{
    public class DAL_Modelos
    {
        DAL_Conexion objConexion = new DAL_Conexion();

        public DAL_Modelos() 
        {
            objConexion.Conectar();
        }

        public List<Modelos> getModelos()
        {
            List<Modelos> listaModelos = new List<Modelos>();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("spObtenerModelos", objConexion.conexion);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd);
                DataTable dataTable = new DataTable();
                objConexion.conexion.Open();
                dataAdapter.Fill(dataTable);
                objConexion.conexion.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    listaModelos.Add(new Modelos
                    {
                        IdModelo = (int)dr["idModelo"],
                        Nombre = (dr["nombre"].ToString() == "" ? "" : (string)dr["nombre"]),
                        Activo = (bool)dr["activo"]
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return listaModelos;
        }

        public decimal registrar(string nombre)
        {
            decimal resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spInsertarModelos", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@nombre", nombre);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();

                objConexion.conexion.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    resultado = (decimal)(dr["idModelo"]);
                }
                objConexion.conexion.Close();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return resultado;
        }

        public int editar(int idModelo, string nombre)
        {
            int resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spEditarModelo", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@idModelo", idModelo);
                sqlCmd.Parameters.AddWithValue("@nombre", nombre);

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

        //public int desactivar(int idRol)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        SqlCommand sqlCmd = new SqlCommand("spDesactivarRol", objConexion.conexion);
        //        sqlCmd.CommandType = CommandType.StoredProcedure;
        //        sqlCmd.Parameters.AddWithValue("@IdRol", idRol);

        //        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        //        DataTable dt = new DataTable();

        //        objConexion.conexion.Open();
        //        da.Fill(dt);
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            resultado = (int)(dr["resultado"]);
        //        }
        //        objConexion.conexion.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        DAL_Utilerias.FormatoExcepcion(ex);
        //    }
        //    return resultado;
        //}
        //public int activar(int idRol)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        SqlCommand sqlCmd = new SqlCommand("spActivarRol", objConexion.conexion);
        //        sqlCmd.CommandType = CommandType.StoredProcedure;
        //        sqlCmd.Parameters.AddWithValue("@IdRol", idRol);

        //        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        //        DataTable dt = new DataTable();

        //        objConexion.conexion.Open();
        //        da.Fill(dt);
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            resultado = (int)(dr["resultado"]);
        //        }
        //        objConexion.conexion.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        DAL_Utilerias.FormatoExcepcion(ex);
        //    }
        //    return resultado;
        //}
    }
}
