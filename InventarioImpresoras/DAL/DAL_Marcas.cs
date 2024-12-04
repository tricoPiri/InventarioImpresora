using InventarioImpresoras.Models;
using System.Data.SqlClient;
using System.Data;

namespace InventarioImpresoras.DAL
{
    public class DAL_Marcas
    {
        DAL_Conexion objConexion = new DAL_Conexion();

        public DAL_Marcas() 
        {
            objConexion.Conectar();
        }

        public List<Marcas> getMarcas()
        {
            List<Marcas> listaMarcas = new List<Marcas>();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("spObtenerMarcas", objConexion.conexion);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd);
                DataTable dataTable = new DataTable();
                objConexion.conexion.Open();
                dataAdapter.Fill(dataTable);
                objConexion.conexion.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    listaMarcas.Add(new Marcas
                    {
                        IdMarca = (int)dr["idMarca"],
                        Nombre = (dr["nombre"].ToString() == "" ? "" : (string)dr["nombre"]),
                        Activo = (bool)dr["activo"]
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return listaMarcas;
        }

        public decimal registrar(string nombre)
        {
            decimal resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spInsertarMarcas", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@nombre", nombre);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();

                objConexion.conexion.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    resultado = (decimal)(dr["idMarca"]);
                }
                objConexion.conexion.Close();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return resultado;
        }

        public int editar(int idMarca, string nombre)
        {
            int resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spEditarMarca", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@idMarca", idMarca);
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
        public int desactivar(int idMarca)
        {
            int resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spDesactivarMarca", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@IdMarca", idMarca);

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
        public int activar(int idMarca)
        {
            int resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spActivarMarca", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@IdMarca", idMarca);

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
