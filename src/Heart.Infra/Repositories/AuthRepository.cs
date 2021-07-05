using System.Threading.Tasks;
using Heart.Infra.Interfaces;
using System.Configuration;
using Heart.Infra.Database;
using System.Data.SqlClient;
using BCrypt.Net;
using System.Data;

namespace Heart.Infra.Repositories
{
    public class AuthRepository : DatabaseString, IAuthRepository
    {
        public async Task<bool> Login(string email, string password)
        {
            // string queryString = @"SELECT Email,Password FROM [Usuarios] WHERE Email=@email AND Password=@password";
            string queryString = @"SELECT Password FROM [Usuarios] WHERE Email=@email";

            using(SqlConnection sqlConnection = new SqlConnection(Conexao()))
            {
                await sqlConnection.OpenAsync();
                using(SqlCommand cmd = new SqlCommand(queryString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    var hashedPassword = (string) await cmd.ExecuteScalarAsync();

                    if(hashedPassword != null) 
                    {
                        bool verify = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                        if (verify != false)
                            return true;
                    }
                                     
                    await sqlConnection.CloseAsync();                    
                    return false;
                }
            }





        }
    }
}