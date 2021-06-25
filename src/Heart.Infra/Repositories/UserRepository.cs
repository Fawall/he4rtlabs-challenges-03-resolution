using System.Collections.Generic;
using System.Threading.Tasks;
using Heart.Domain.Entities;
using Heart.Infra.Interfaces;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace Heart.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        string conn = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public async Task<User> GetByEmail(string email)
        {
            string queryString = @"SELECT Email FROM Usuarios WHERE email=@email";
            using(SqlConnection sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                using(SqlCommand cmd = new SqlCommand(queryString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    
                    var userEmail = cmd.ExecuteScalar();
                    await sqlConnection.CloseAsync();
                    
                    return (User)userEmail;
                }                
            }           
        }

        public Task<List<User>> SearchByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}