using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Stocks.Queries.GetList;

public class GetListStockQuery : IRequest<GetListResponse<GetListStockListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListStockQueryHandler : IRequestHandler<GetListStockQuery, GetListResponse<GetListStockListItemDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetListStockQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStockListItemDto>> Handle(GetListStockQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Stock> stocks = await _stockRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStockListItemDto> response = _mapper.Map<GetListResponse<GetListStockListItemDto>>(stocks);
            return response;
        }
    }
}