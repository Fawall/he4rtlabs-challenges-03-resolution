using System.Collections.Generic;
using System.Threading.Tasks;
using Heart.Domain.Entities;
using Heart.Infra.Interfaces;
using System.Data.SqlClient;
using System.Configuration;
using Heart.Infra.Database;
using BCrypt.Net;


namespace Heart.Infra.Repositories
{
    public class BaseRepository<T> : DatabaseString, IBaseRepository<T> where T : User
    {
        public virtual async Task<T> Create(T obj)
        {
            string queryString = $@"INSERT INTO Usuarios (email, password) VALUES (@email, @password)";
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(obj.Password);

            using(SqlConnection sqlConnection = new SqlConnection(Conexao()))
            {
                await sqlConnection.OpenAsync();
                
                using(SqlCommand cmd = new SqlCommand(queryString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@password", passwordHash);
                    await cmd.ExecuteNonQueryAsync();
                }
                await sqlConnection.CloseAsync();     
            }
            return obj;
        }

        public virtual async Task<T> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<List<string>> GetAll()
        {
            List<string> emails = new List<string>();    
        
            string queryString = @"SELECT Email From [Usuarios]";

            using(SqlConnection sqlConnection = new SqlConnection(Conexao()))
            {
                await sqlConnection.OpenAsync();
                using(SqlCommand cmd = new SqlCommand(queryString, sqlConnection))
                {                 
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    if(dr.HasRows)
                    {
                        while(await dr.ReadAsync())
                        {
                            emails.Add(dr["email"].ToString());
                        }
                        await dr.CloseAsync();
                        return emails;
                    }

                    await sqlConnection.CloseAsync();
                    
                    return emails;
                }
            } 
        }
    }
}