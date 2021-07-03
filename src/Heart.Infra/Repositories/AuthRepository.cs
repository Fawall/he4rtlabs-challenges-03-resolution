using System.Threading.Tasks;
using Heart.Infra.Interfaces;
using System.Configuration;
using Heart.Infra.Database;
using System.Data.SqlClient;


namespace Heart.Infra.Repositories
{
    public class AuthRepository : DatabaseString, IAuthRepository
    {
        public async Task<bool> Login(string email, string password)
        {
            string queryString = @"SELECT Email,Password FROM [Usuarios] WHERE Email=@email AND Password=@password";

            using(SqlConnection sqlConnection = new SqlConnection(Conexao()))
            {
                await sqlConnection.OpenAsync();
                using(SqlCommand cmd = new SqlCommand(queryString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    if(dr.HasRows)
                        return true;
                        
                    return false;
                }
            }





        }
    }
}