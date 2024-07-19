using FluentValidation;

namespace ExperienciaTecno.BackEnd.Core.Product.Validators;

public class ProductValidator : AbstractValidator<Models.Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("El nombre no debe estar vacío.")
            .MaximumLength(100).WithMessage("El nombre no debe exceder los 100 caracteres.");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("La descripción no debe estar vacía.")
            .MaximumLength(500).WithMessage("La descripción no debe exceder los 500 caracteres.");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("El precio debe ser mayor que cero.")
            .ScalePrecision(2, 18).WithMessage("El precio debe tener como máximo dos decimales.");

        RuleFor(p => p.ImagePath1)
            .NotEmpty().WithMessage("La primera ruta de la imagen no debe estar vacía.");

        //RuleFor(p => p.ManufacturerId)
        //    .GreaterThan(0).WithMessage("El ID del fabricante debe ser mayor que cero.");

        //RuleFor(p => p.CategoryId)
        //    .GreaterThan(0).WithMessage("El ID de la categoría debe ser mayor que cero.");
    }
}
