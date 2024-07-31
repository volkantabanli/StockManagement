using Core.Application.Responses;

namespace Application.Features.Models.Commands.Update;

public class UpdatedModelResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MaterialId { get; set; }
}