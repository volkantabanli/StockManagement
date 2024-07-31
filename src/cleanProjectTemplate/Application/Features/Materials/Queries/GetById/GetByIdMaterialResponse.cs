using Core.Application.Responses;
namespace Application.Features.Materials.Queries.GetById;
public class GetByIdMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Engine { get; set; }
    public string Year { get; set; }
    public double Price { get; set; }
}