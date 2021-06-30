using System.Collections.Generic;
using Heart.Domain.Validators;
using System;

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

        public User(string email)
        {
            Email = email;
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                
                throw new Exception("Alguns campos estão inválidos corrija-os " + _errors[0]);
            }
            return true;
        }



    }
}