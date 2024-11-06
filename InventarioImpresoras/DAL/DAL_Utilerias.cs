using System.IO;
using System.Text;

namespace InventarioImpresoras.DAL
{
    public static class DAL_Utilerias
    {
		public static void FormatoExcepcion(Exception ex)
		{
			string nombreArchivo = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + DateTime.Now.Microsecond + ".txt";
			string path = Directory.GetCurrentDirectory() + "/" + "wwwroot/logs/";
			
			if(!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
            
			using (StreamWriter w = File.AppendText(path + nombreArchivo))
            {
				w.WriteLine("\n");
				w.WriteLine("[Fecha:] " + DateTime.Now.ToString("dddd, dd MMMM yyyy HH: mm:ss") + "\n  [Mensaje Error:] " + ex.Message + "\n [InnerException:] " + ex.InnerException + "\n [StackTrace:] " + ex.StackTrace);
				w.WriteLine("\n");
				w.Flush();
				w.Close();
			}
		}
	}
}
