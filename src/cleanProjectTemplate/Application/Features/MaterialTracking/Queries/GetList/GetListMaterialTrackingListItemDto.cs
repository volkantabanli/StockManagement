using Core.Application.Dtos;

namespace Application.Features.MaterialTracking.Queries.GetList;

public class GetListMaterialTrackingListItemDto : IDto
{
    public Guid Id { get; set; }
    public string MaterialCode { get; set; }
    public string MaterialName { get; set; }
    public string ModelName { get; set; }
    public string Engine { get; set; }
    public string Year { get; set; }
    public double? Price { get; set; } = 0;
    public int? StockMRK { get; set; } = 0;
    public int? StockIZM { get; set; } = 0;
    public int? StockANK { get; set; } = 0;
    public int? StockADN { get; set; } = 0;
    public int? StockERZ { get; set; } = 0;
}