using Core.Application.Responses;

namespace Application.Features.Models.Commands.Create;

public class CreatedModelResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MaterialId { get; set; }
}