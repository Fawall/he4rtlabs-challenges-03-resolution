using System.Collections.Generic;
using System.Threading.Tasks;
using Heart.Domain.Entities;
using Heart.Infra.Interfaces;
using System.Data.SqlClient;
using System.Configuration;
using System;
using Heart.Infra.Databases;

namespace Heart.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public async Task<User> GetByEmail(string email)
        {
            User user = null;
            string queryString = @"SELECT email FROM [Usuarios] WHERE email=@email";
            
            using(SqlConnection sqlConnection = new SqlConnection(Conexao()))
            {
                await sqlConnection.OpenAsync();
                using(SqlCommand cmd = new SqlCommand(queryString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    if (dr.HasRows)
                    {
                        user = new User(email);
                        return user;
                    }

                    await sqlConnection.CloseAsync();
                    await dr.CloseAsync();

                    return user;
                }
            }
        }           

        public Task<List<User>> SearchByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}