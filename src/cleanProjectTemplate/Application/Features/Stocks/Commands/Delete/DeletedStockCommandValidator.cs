using FluentValidation;

namespace Application.Features.Stocks.Commands.Delete;

public class DeleteStockCommandValidator : AbstractValidator<DeleteStockCommand>
{
    public DeleteStockCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}