using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Stocks;

public interface IStocksService
{
    Task<Stock?> GetAsync(
        Expression<Func<Stock, bool>> predicate,
        Func<IQueryable<Stock>, IIncludableQueryable<Stock, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Stock>?> GetListAsync(
        Expression<Func<Stock, bool>>? predicate = null,
        Func<IQueryable<Stock>, IOrderedQueryable<Stock>>? orderBy = null,
        Func<IQueryable<Stock>, IIncludableQueryable<Stock, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Stock> AddAsync(Stock stock);
    Task<Stock> UpdateAsync(Stock stock);
    Task<Stock> DeleteAsync(Stock stock, bool permanent = false);
}
