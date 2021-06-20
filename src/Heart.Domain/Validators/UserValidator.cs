using FluentValidation;
using Heart.Domain.Entities;

namespace Heart.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("A entidade não pode ser vazia")
                
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia");
    
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo")
                
                .NotEmpty()
                .WithMessage("O email não pode ser vazio")

                .MinimumLength(10)
                .WithMessage("O email tem que ter no mínimo 10 caractéres")

                .MaximumLength(180)
                .WithMessage("O email tem que ter no máximo 180 caractéres")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é válido");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("A senha não pode ser nula")
                
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caractéres")

                .MaximumLength(40)
                .WithMessage("A senha deve ter no máximo 40 caractéres");
        }


    }
}