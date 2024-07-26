using FluentValidation;

namespace ExperienciaTecno.BackEnd.Core.Manufacturer.Validators;

public class ManufacturerValidator : AbstractValidator<Models.Manufacturer>
{
    public ManufacturerValidator()
    {
        RuleFor(manufacturer => manufacturer.Name)
            .NotEmpty().WithMessage("El nombre es requerido.")
            .Length(2, 100).WithMessage("El nombre debe tener entre 2 y 100 caracteres.");
    }
}
