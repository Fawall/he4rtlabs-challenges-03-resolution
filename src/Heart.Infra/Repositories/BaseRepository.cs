using System.Collections.Generic;
using System.Threading.Tasks;
using Heart.Domain.Entities;
using Heart.Infra.Interfaces;
using System.Data.SqlClient;
using System.Configuration;
using Heart.Infra.Database;
using Heart.Infra.DTO;
using BCrypt.Net;
using System;

namespace Heart.Infra.Repositories
{
    public class BaseRepository<T> : DatabaseString, IBaseRepository<T> where T : User
    {

        public virtual async Task<T> Create(T obj)
        {
            DateTime CreatedUser = DateTime.Now.Date ;
            
            string queryString = $@"INSERT INTO Usuarios(email, password, CreatedUserDate) VALUES (@email, @password, @CreatedUser)";
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(obj.Password);

            using(SqlConnection sqlConnection = new SqlConnection(Conexao()))
            {
                await sqlConnection.OpenAsync();
                
                using(SqlCommand cmd = new SqlCommand(queryString, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@password", passwordHash);
                    cmd.Parameters.AddWithValue("@CreatedUser", CreatedUser);
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

        public virtual async Task<List<UserDataDTO>> GetAll()
        {
            List<UserDataDTO> userData = new List<UserDataDTO>();  
        
            string queryString = @"SELECT Email,CreatedUserDate From [Usuarios]";

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
                            userData.Add( new UserDataDTO(){ Email = dr["email"].ToString(), CreatedAt = dr["CreatedUserDate"].ToString().Remove(10)});
                        }
                        await dr.CloseAsync();
                        await sqlConnection.CloseAsync();
                        

                        return userData;
                    }

                    await sqlConnection.CloseAsync();

                    
                    return userData;
                }
            } 
        }
    }
}