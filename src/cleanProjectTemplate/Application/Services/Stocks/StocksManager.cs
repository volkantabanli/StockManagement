using Application.Features.Stocks.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Stocks;

public class StocksManager : IStocksService
{
    private readonly IStockRepository _stockRepository;
    private readonly StockBusinessRules _stockBusinessRules;

    public StocksManager(IStockRepository stockRepository, StockBusinessRules stockBusinessRules)
    {
        _stockRepository = stockRepository;
        _stockBusinessRules = stockBusinessRules;
    }

    public async Task<Stock?> GetAsync(
        Expression<Func<Stock, bool>> predicate,
        Func<IQueryable<Stock>, IIncludableQueryable<Stock, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Stock? stock = await _stockRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return stock;
    }

    public async Task<IPaginate<Stock>?> GetListAsync(
        Expression<Func<Stock, bool>>? predicate = null,
        Func<IQueryable<Stock>, IOrderedQueryable<Stock>>? orderBy = null,
        Func<IQueryable<Stock>, IIncludableQueryable<Stock, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Stock> stockList = await _stockRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return stockList;
    }

    public async Task<Stock> AddAsync(Stock stock)
    {
        Stock addedStock = await _stockRepository.AddAsync(stock);

        return addedStock;
    }

    public async Task<Stock> UpdateAsync(Stock stock)
    {
        Stock updatedStock = await _stockRepository.UpdateAsync(stock);

        return updatedStock;
    }

    public async Task<Stock> DeleteAsync(Stock stock, bool permanent = false)
    {
        Stock deletedStock = await _stockRepository.DeleteAsync(stock);

        return deletedStock;
    }
}
