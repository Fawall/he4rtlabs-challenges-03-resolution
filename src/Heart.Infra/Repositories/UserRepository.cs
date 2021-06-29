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
            throw new System.NotImplementedException();          
        }           

        public Task<List<User>> SearchByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}