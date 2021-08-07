using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heart.Infra.Interfaces;
using ServiceStack.Redis;
using Newtonsoft.Json;

namespace Heart.Infra.Repositories
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IUserRepository _userRepository;
        public RedisRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<string>> GetValuesFromRedis()
        {
            RedisEndpoint redisEndpoint = new RedisEndpoint("localhost", 6379);

            using(RedisClient client = new RedisClient(redisEndpoint))
            {
                if(client.ContainsKey("usuarios") != false)
                {
                    var emailRetornado = client.GetValue("usuarios");
                    List<string> email = JsonConvert.DeserializeObject<List<string>>(emailRetornado);
                    return email;             
                }
                
                var usuarios = await _userRepository.GetAll();
                client.Add("usuarios", usuarios, TimeSpan.FromMinutes(5));            
                var emailsRetornados = client.GetValue("usuarios");
                
                List<string> emails = JsonConvert.DeserializeObject<List<string>>(emailsRetornados);    

                return emails;
            }
        }
    }
}