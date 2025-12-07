using API.DTOs;
using FluentValidation;

namespace API.Validators
{
    public class RentalValidator : AbstractValidator<RentalRequestDto>
    {
        public RentalValidator()
        {
            RuleFor(x => x.MachineryId).GreaterThan(0);
            RuleFor(x => x.StartDate)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("No podemos viajar al pasado, seleccione una fecha futura.");
            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .WithMessage("La fecha de devolución debe ser después de la fecha de inicio.");
        }
    }
}