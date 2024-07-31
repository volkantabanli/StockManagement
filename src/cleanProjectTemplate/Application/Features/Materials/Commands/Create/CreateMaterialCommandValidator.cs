using FluentValidation;
namespace Application.Features.Materials.Commands.Create;
public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
    }
}