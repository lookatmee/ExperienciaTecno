using FluentValidation;

namespace ExperienciaTecno.BackEnd.Core.Category.Validators;

public class CategoryValidator : AbstractValidator<Models.Category>
{
    public CategoryValidator() 
    {
        RuleFor(category => category.Name)
            .NotEmpty().WithMessage("El nombre de categoría es requerido.")
            .MaximumLength(100).WithMessage("El nombre de categoría no puede exceder los 100 caracteres.");
    }
}
