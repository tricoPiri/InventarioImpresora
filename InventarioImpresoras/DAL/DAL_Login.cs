using System.Data.SqlClient;
using System.Data;
//using Serilog;
using InventarioImpresoras.Models;

namespace InventarioImpresoras.DAL
{
    public class DAL_Login
    {
        //objConexion objConexion = new objConexion();
        public DAL_Login()
        {
            //objConexion.Conectar();
        }
        /*
        public List<Login> Login(string usuario, string password)
        {
            List<Login> listaLogin = new List<Login>();
            try
            {
                SqlCommand command = new SqlCommand("Rh-Emp.Usuario_Login", objConexion.conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Contraseña", password);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                objConexion.conexion.Open();
                dataAdapter.Fill(dataTable);
                objConexion.conexion.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    listaLogin.Add(new Login
                    {
                        IdUsuario = (int)dr["id_Usuario"],
                        Usuario = (string)dr["Usuario"],
                    });
                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }

            return listaLogin;
        }
		public List<Permiso> obtenerPermisos(int usuario_id)
		{
			List<Permiso> listaLogin = new List<Permiso>();
			try
			{
				SqlCommand command = new SqlCommand("Rh-Emp.Usuario_ExpRH", objConexion.conexion);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@Usuario_id", usuario_id);

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
				DataTable dataTable = new DataTable();
				objConexion.conexion.Open();
				dataAdapter.Fill(dataTable);
				objConexion.conexion.Close();

				foreach (DataRow dr in dataTable.Rows)
				{
					listaLogin.Add(new Permiso
					{
						Usuario_Id = (int)dr["Usuario_id"],
						Admin = (bool)dr["Adm_"],
                        Aux_BD = (bool)dr["Aux_BD"],
                        Exp_RH = (bool)dr["Exp_RH"],
                        Aux_Ipsset = (bool)dr["Aux_Ipsset"],
                    });
				}
			}
			catch (Exception ex)
			{
				DAL_Utilerias.FormatoExcepcion(ex);
			}

			return listaLogin;
		}
        */
	}
}
