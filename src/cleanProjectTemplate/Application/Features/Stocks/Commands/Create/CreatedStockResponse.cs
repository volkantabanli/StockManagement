using Core.Application.Responses;

namespace Application.Features.Stocks.Commands.Create;

public class CreatedStockResponse : IResponse
{
    public Guid Id { get; set; }
    public int StokMRK { get; set; }
    public int StokIZM { get; set; }
    public int StokANK { get; set; }
    public int StokADN { get; set; }
    public int StokERZ { get; set; }
    public Guid MaterialId { get; set; }
}