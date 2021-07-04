namespace Heart.API.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(string email);
    }
}