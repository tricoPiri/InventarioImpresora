using InventarioImpresoras.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventarioImpresoras.DAL
{
    public class DAL_Impresoras
    {
        DAL_Conexion objConexion = new DAL_Conexion();
        public DAL_Impresoras()
        {
            objConexion.Conectar();
        }

        public List<Impresoras> getImpresoras()
        {
            List<Impresoras> listaImpresoras = new List<Impresoras>();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("spObtenerImpresoras", objConexion.conexion);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd);
                DataTable dataTable = new DataTable();
                objConexion.conexion.Open();
                dataAdapter.Fill(dataTable);
                objConexion.conexion.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    listaImpresoras.Add(new Impresoras
                    {
                        IdImpresora = (int)dr["idImpresora"],
                        Nombre = (dr["Impresora"].ToString() == "" ? "" : (string)dr["Impresora"]),
                        NumeroSerie = (dr["numeroSerie"].ToString() == "" ? "" : (string)dr["numeroSerie"]),
                        Activo = (bool)dr["activo"],
                        Marcas = new List<Marcas>
                        {
                            new Marcas()
                            {
                                IdMarca = (int)dr["idMarca"],
                                Nombre = (dr["Marca"].ToString() == "" ? "" : (string)dr["Marca"]),
                            }
                        },
                        Modelos = new List<Modelos>
                        {
                            new Modelos()
                            {
                                IdModelo = (int)dr["idModelo"],
                                Nombre = (dr["Modelo"].ToString() == "" ? "" : (string)dr["Modelo"]),
                            }
                        },
                        Areas = new List<Areas>
                        {
                            new Areas()
                            {
                                IdArea = (int)dr["idArea"],
                                Nombre = (dr["Area"].ToString() == "" ? "" : (string)dr["Area"]),
                            }
                        },
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return listaImpresoras;
        }
        public decimal registrar(string numeroSerie, string nombre, int idMarca, int idModelo, int idArea)
        {
            decimal resultado = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spInsertarImpresoras", objConexion.conexion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@numeroSerie", numeroSerie);
                sqlCmd.Parameters.AddWithValue("@nombre", nombre);
                sqlCmd.Parameters.AddWithValue("@idMarca", idMarca);
                sqlCmd.Parameters.AddWithValue("@idModelo", idModelo);
                sqlCmd.Parameters.AddWithValue("@idArea", idArea);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();

                objConexion.conexion.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    resultado = (decimal)(dr["idImpresora"]);
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
