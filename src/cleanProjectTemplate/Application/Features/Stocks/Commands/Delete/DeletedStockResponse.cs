using Core.Application.Responses;

namespace Application.Features.Stocks.Commands.Delete;

public class DeletedStockResponse : IResponse
{
    public Guid Id { get; set; }
}