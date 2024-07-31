using Application.Features.Stocks.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Stocks.Rules;

public class StockBusinessRules : BaseBusinessRules
{
    private readonly IStockRepository _stockRepository;

    public StockBusinessRules(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public Task StockShouldExistWhenSelected(Stock? stock)
    {
        if (stock == null)
            throw new BusinessException(StocksBusinessMessages.StockNotExists);
        return Task.CompletedTask;
    }

    public async Task StockIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Stock? stock = await _stockRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StockShouldExistWhenSelected(stock);
    }

    public async Task StockMaterialCannotBeDuplicatedWhenInserted(Guid MaterialId)
    {
        Stock? result = await _stockRepository.GetAsync(predicate: b => b.MaterialId== MaterialId);

        if (result != null)
        {
            throw new BusinessException(StocksBusinessMessages.StockMaterialExists);
        }
    }

    public async Task StockMaterialCannotBeDuplicatedWhenUpdated(Guid stockId, Guid MaterialId)
    {
        Stock? result = await _stockRepository.GetAsync(predicate: b => b.MaterialId == MaterialId && b.Id != stockId);

        if (result != null)
        {
            throw new BusinessException(StocksBusinessMessages.StockMaterialExists);
        }
    }
}