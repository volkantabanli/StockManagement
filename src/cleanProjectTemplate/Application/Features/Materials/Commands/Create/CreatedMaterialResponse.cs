using Core.Application.Responses;
namespace Application.Features.Materials.Commands.Create;
public class CreatedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Engine { get; set; }
    public string Year { get; set; }
    public double Price { get; set; }
}