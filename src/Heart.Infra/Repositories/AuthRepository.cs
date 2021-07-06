using System.Threading.Tasks;
using Heart.Infra.Interfaces;
using System.Configuration;
using Heart.Infra.Database;
using System.Data.SqlClient;
using BCrypt.Net;
using System.Data;
using Heart.Infra.VerifyHash;
using Heart.Infra.VerifyHash.Interfaces;

namespace Heart.Infra.Repositories
{
    public class AuthRepository : DatabaseString, IAuthRepository
    {
        private readonly IVerifyHashPassword _verifyHash;
        public AuthRepository(IVerifyHashPassword verifyHash)
        {
            _verifyHash = verifyHash;
        }
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

                    var hashPassword = (string) await cmd.ExecuteScalarAsync();

                    if(hashPassword != null) 
                    {
                        return _verifyHash.hashPassword(password, hashPassword);
                    }
                                     
                    await sqlConnection.CloseAsync();                    
                    return false;
                }
            }





        }
    }
}