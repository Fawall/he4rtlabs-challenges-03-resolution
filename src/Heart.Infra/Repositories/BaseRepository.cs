using System.Collections.Generic;
using System.Threading.Tasks;
using Heart.Domain.Entities;
using Heart.Infra.Interfaces;
using System.Data.SqlClient;
using System.Configuration;
using Heart.Infra.Databases;

namespace Heart.Infra.Repositories
{
    public class BaseRepository<T> : Database, IBaseRepository<T> where T : User
    {
        public virtual async Task<T> Create(T obj)
        {
            string queryString = $@"INSERT INTO Usuarios (email, password) VALUES (@email, @password)";

            using(SqlConnection sqlConnection = new SqlConnection(Conexao()))
            {
                await sqlConnection.OpenAsync();
                
                using(SqlCommand cmd = new SqlCommand(queryString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@password", obj.Password);
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

        public virtual async Task<List<T>> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}