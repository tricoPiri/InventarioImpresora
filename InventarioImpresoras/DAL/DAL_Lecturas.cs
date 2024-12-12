using InventarioImpresoras.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventarioImpresoras.DAL
{
    public class DAL_Lecturas
    {
        DAL_Conexion objConexion = new DAL_Conexion();
        public DAL_Lecturas()
        {
            objConexion.Conectar();
        }

        public List<Meses> getMeses()
        {
            List<Meses> listaMeses = new List<Meses>();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("spObtenerMeses", objConexion.conexion);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd);
                DataTable dataTable = new DataTable();
                objConexion.conexion.Open();
                dataAdapter.Fill(dataTable);
                objConexion.conexion.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    listaMeses.Add(new Meses
                    {
                        IdMes = (int)dr["idMes"],
                        Nombre = (dr["nombre"].ToString() == "" ? "" : (string)dr["nombre"]),
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return listaMeses;
        }
        public List<Lecturas> getLecturas()
        {
            List<Lecturas> listaLecturas = new List<Lecturas>();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("spObtenerLecturas", objConexion.conexion);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd);
                DataTable dataTable = new DataTable();
                objConexion.conexion.Open();
                dataAdapter.Fill(dataTable);
                objConexion.conexion.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    listaLecturas.Add(new Lecturas
                    {
                        IdLectura = (int)dr["idLectura"],
                        FechaLectura = (DateTime)dr["fechaLectura"],
                        LecturaAnterior = (int)dr["lecturaAnterior"],
                        LecturaActual = (int)dr["lecturaActual"],
                        Observaciones = (dr["observaciones"].ToString() == "" ? "" : (string)dr["observaciones"]),
                        NumeroCopias = (int)dr["numeroCopias"],

                        Impresoras = new List<Impresoras>
                        {
                            new Impresoras()
                            {
                                NumeroSerie = (dr["numeroSerie"].ToString() == "" ? "" : (string)dr["numeroSerie"]),
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
                            }
                        },
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return listaLecturas;
        }
    }
}