using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heart.Infra.Interfaces;
using ServiceStack.Redis;
using Newtonsoft.Json;
using Heart.Infra.DTO;

namespace Heart.Infra.Repositories
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IUserRepository _userRepository;
        public RedisRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDataDTO>> GetValuesFromRedis()
        {
            RedisEndpoint redisEndpoint = new RedisEndpoint("localhost", 6379);

            using(RedisClient client = new RedisClient(redisEndpoint))
            {
                if(client.ContainsKey("usuarios") != false)
                {
                    var emailRetornado = client.GetValue("usuarios");
                    List<UserDataDTO> email = JsonConvert.DeserializeObject<List<UserDataDTO>>(emailRetornado);
                    
                    return email;             
                }
                
                var usuarios = await _userRepository.GetAll();
                
                client.Add("usuarios", usuarios, TimeSpan.FromMinutes(5));            
                var emailsRetornados = client.GetValue("usuarios");
                
                List<UserDataDTO> emails = JsonConvert.DeserializeObject<List<UserDataDTO>>(emailsRetornados);    

                return emails;
            }
        }
    }
}