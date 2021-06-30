using System.Configuration;

namespace Heart.Infra.Databases
{
    public class Database 
    {
        public string Conexao()
        {
           string conn = ConfigurationManager.AppSettings["SqlConnection"];
           return conn;
        }

    }
}