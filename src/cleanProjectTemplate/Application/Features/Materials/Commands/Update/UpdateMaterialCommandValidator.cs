using FluentValidation;
namespace Application.Features.Materials.Commands.Update;
public class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.Engine).NotEmpty();
        RuleFor(c => c.Year).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
    }
}