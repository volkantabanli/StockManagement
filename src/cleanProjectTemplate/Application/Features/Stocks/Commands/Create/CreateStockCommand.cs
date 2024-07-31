using Application.Features.Stocks.Constants;
using Application.Features.Stocks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Stocks.Constants.StocksOperationClaims;

namespace Application.Features.Stocks.Commands.Create;

public class CreateStockCommand : IRequest<CreatedStockResponse>, ISecuredRequest
{
    public int StokMRK { get; set; }
    public int StokIZM { get; set; }
    public int StokANK { get; set; }
    public int StokADN { get; set; }
    public int StokERZ { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => new[] { Admin, Write, StocksOperationClaims.Create };

    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, CreatedStockResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly StockBusinessRules _stockBusinessRules;

        public CreateStockCommandHandler(IMapper mapper, IStockRepository stockRepository,
                                         StockBusinessRules stockBusinessRules)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _stockBusinessRules = stockBusinessRules;
        }

        public async Task<CreatedStockResponse> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            await _stockBusinessRules.StockMaterialCannotBeDuplicatedWhenInserted(request.MaterialId);
            Stock stock = _mapper.Map<Stock>(request);
            await _stockRepository.AddAsync(stock);
            CreatedStockResponse response = _mapper.Map<CreatedStockResponse>(stock);
            return response;
        }
    }
}