using FluentValidation;

namespace ExperienciaTecno.BackEnd.Core.Manufacturer.Validators;

public class ManufacturerValidator : AbstractValidator<Models.Manufacturer>
{
    public ManufacturerValidator()
    {
        RuleFor(manufacturer => manufacturer.Name)
            .NotEmpty().WithMessage("El nombre es requerido.")
            .Length(2, 100).WithMessage("El nombre debe tener entre 2 y 100 caracteres.");

        RuleFor(manufacturer => manufacturer.Address)
            .NotEmpty().WithMessage("La dirección es requerida.")
            .Length(5, 200).WithMessage("La dirección debe tener entre 5 y 200 caracteres.");

        RuleFor(manufacturer => manufacturer.Phone)
            .NotEmpty().WithMessage("El teléfono es requerido.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("El teléfono debe ser válido y contener entre 10 y 15 dígitos.");
    }
}
