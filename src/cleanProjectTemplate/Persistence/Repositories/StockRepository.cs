using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StockRepository : EfRepositoryBase<Stock, Guid, BaseDbContext>, IStockRepository
{
    public StockRepository(BaseDbContext context) : base(context)
    {
    }
}