using Application.Features.Materials.Queries.GetList;
using Application.Services.Repositories;
using Application.Services.UserOperationClaims;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.MaterialTracking.Queries.GetList;

public class GetListMaterialTrackingQuery : IRequest<List<GetListMaterialTrackingListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListMaterialTrackingQueryHandler : IRequestHandler<GetListMaterialTrackingQuery, List<GetListMaterialTrackingListItemDto>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetListMaterialTrackingQueryHandler(IMaterialRepository materialRepository, IModelRepository modelRepository, IStockRepository stockRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _modelRepository = modelRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListMaterialTrackingListItemDto>> Handle(GetListMaterialTrackingQuery request, CancellationToken cancellationToken)
        {

            var materials = await _materialRepository.GetListAllAsync();
            var models = await _modelRepository.GetListAllAsync();
            var stocks = await _stockRepository.GetListAllAsync();
            var listGetListMaterialTrackingListItemDto = new List<GetListMaterialTrackingListItemDto>();
            if (materials != null && materials.Any())
            {
                foreach (var item in materials)
                {
                    var model = models.Where(a => a.MaterialId == item.Id).ToList();
                    var stock = stocks.Where(a => a.MaterialId == item.Id).FirstOrDefault(); // Sadece bir kayıt olması sağlanıcak.
                    var getListMaterialTrackingListItemDto = new GetListMaterialTrackingListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        MaterialCode = item.Code,
                        MaterialName = item.Name,
                        ModelName = string.Join("/", model.Select(m => m.Name)),
                        Engine = item.Engine,
                        Year = item.Year,
                        Price = item.Price,
                        StockMRK = stock?.StokMRK ?? 0,
                        StockIZM = stock?.StokIZM ?? 0,
                        StockANK = stock?.StokANK ?? 0,
                        StockADN = stock?.StokADN ?? 0,
                        StockERZ = stock?.StokERZ ?? 0,
                    };
                    listGetListMaterialTrackingListItemDto.Add(getListMaterialTrackingListItemDto);
                }
            }
            return listGetListMaterialTrackingListItemDto;
        }
    }
}