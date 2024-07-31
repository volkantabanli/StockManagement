using Core.Application.Dtos;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MaterialId { get; set; }
}