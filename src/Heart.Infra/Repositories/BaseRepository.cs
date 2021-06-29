using System.Collections.Generic;
using System.Threading.Tasks;
using Heart.Domain.Entities;
using Heart.Infra.Interfaces;
using System.Data.SqlClient;

using System.Configuration;

namespace Heart.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : User
    {
        // string conn = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString  ;
        public virtual async Task<T> Create(T obj)
        {
            string queryString = $@"INSERT INTO Usuarios (email, password) VALUES (@email, @password)";

            using(SqlConnection sqlConnection = new SqlConnection("Server=localhost,1401;Database=HeartChallenge03; User ID=Sa;Password=Fab@o123; MultipleActiveResultSets=true"))
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