using BCrypt.Net;
using Heart.Infra.VerifyHash.Interfaces;

namespace Heart.Infra.VerifyHash
{
    public class VerifyHashPassword : IVerifyHashPassword
    {
        public bool hashPassword(string password, string passwordHash)
        {
            bool verify = BCrypt.Net.BCrypt.Verify(password, passwordHash);

            if(verify != false)
                return true;
            
            return false;
        }
    }
}