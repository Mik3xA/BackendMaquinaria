using API.DTOs;
using FluentValidation;

namespace API.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio, pariente.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Ponga un correo válido.");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");
        }
    }

    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}