using System.Configuration;

namespace Heart.Infra.Database
{
    public class DatabaseString
    {
        public string Conexao()
        {
           string conn = ConfigurationManager.AppSettings["SqlConnection"];
           return conn;
        }

    }
}