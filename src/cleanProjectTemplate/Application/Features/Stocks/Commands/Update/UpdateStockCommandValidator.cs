using FluentValidation;

namespace Application.Features.Stocks.Commands.Update;

public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
{
    public UpdateStockCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}