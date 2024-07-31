using Application.Features.Stocks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Stocks.Queries.GetById;

public class GetByIdStockQuery : IRequest<GetByIdStockResponse>
{
    public Guid Id { get; set; }
    public class GetByIdStockQueryHandler : IRequestHandler<GetByIdStockQuery, GetByIdStockResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly StockBusinessRules _stockBusinessRules;

        public GetByIdStockQueryHandler(IMapper mapper, IStockRepository stockRepository, StockBusinessRules stockBusinessRules)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _stockBusinessRules = stockBusinessRules;
        }

        public async Task<GetByIdStockResponse> Handle(GetByIdStockQuery request, CancellationToken cancellationToken)
        {
            Stock? stock = await _stockRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _stockBusinessRules.StockShouldExistWhenSelected(stock);

            GetByIdStockResponse response = _mapper.Map<GetByIdStockResponse>(stock);
            return response;
        }
    }
}