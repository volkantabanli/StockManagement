using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaterialRepository : IAsyncRepository<Material, Guid>, IRepository<Material, Guid>
{
}