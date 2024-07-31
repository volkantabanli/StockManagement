using Core.Application.Responses;

namespace Application.Features.Models.Queries.GetById;

public class GetByIdModelResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MaterialId { get; set; }
}