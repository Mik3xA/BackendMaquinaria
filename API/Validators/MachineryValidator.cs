using API.DTOs;
using FluentValidation;

namespace API.Validators
{
    public class MachineryValidator : AbstractValidator<MachineryDto>
    {
        public MachineryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre de la máquina es requerido.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("El precio debe ser mayor a 0 pesos.");
            RuleFor(x => x.Description).MaximumLength(2000).WithMessage("Se pasó de rollo con la descripción.");
        }
    }
}