using FluentValidation;

namespace Application.Features.Stocks.Commands.Create;

public class CreateStockCommandValidator : AbstractValidator<CreateStockCommand>
{
    public CreateStockCommandValidator()
    {
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}