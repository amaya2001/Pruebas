using System.Data.SqlClient;

namespace CRUD_CORE.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        public Conexion() { 
            var bulider = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = bulider.GetSection("ConnectionStrings:CadenaSQL").Value;
        }
        public string getCadenaSQL() { 
            return cadenaSQL;
        }
    }
}
