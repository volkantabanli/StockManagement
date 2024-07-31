using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStockRepository : IAsyncRepository<Stock, Guid>, IRepository<Stock, Guid>
{
}