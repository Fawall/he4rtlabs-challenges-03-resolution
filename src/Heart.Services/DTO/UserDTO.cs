namespace Heart.Services.DTO
{
    public class UserDTO
    {
        public long Id {get; set;}
        public string Email {get; set; }
        public string Password {get; set; }

        public UserDTO() {}

        public UserDTO(long id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
        
    }
}