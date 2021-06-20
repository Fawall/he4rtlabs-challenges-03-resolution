using System.Collections.Generic;

namespace Heart.Domain.Entities
{
    public class User : Base
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        protected User(){}

        public User(string email, string password)
        {
            Email = email;
            Password = password;
            _errors = new List<string>();
            Validate();
        }

        public override bool Validate()
        {
            throw new System.NotImplementedException();
        }



    }
}