namespace Heart.Infra.VerifyHash.Interfaces
{
    public interface IVerifyHashPassword
    {
        bool hashPassword(string password, string hashPassword);
    }
}