using Application.Features.Stocks.Constants;
using Application.Features.Stocks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Stocks.Constants.StocksOperationClaims;

namespace Application.Features.Stocks.Commands.Update;

public class UpdateStockCommand : IRequest<UpdatedStockResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public int StokMRK { get; set; }
    public int StokIZM { get; set; }
    public int StokANK { get; set; }
    public int StokADN { get; set; }
    public int StokERZ { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => new[] { Admin, Write, StocksOperationClaims.Update };

    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, UpdatedStockResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly StockBusinessRules _stockBusinessRules;

        public UpdateStockCommandHandler(IMapper mapper, IStockRepository stockRepository,
                                         StockBusinessRules stockBusinessRules)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _stockBusinessRules = stockBusinessRules;
        }

        public async Task<UpdatedStockResponse> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            Stock? stock = await _stockRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _stockBusinessRules.StockShouldExistWhenSelected(stock);
            await _stockBusinessRules.StockMaterialCannotBeDuplicatedWhenUpdated(request.Id,request.MaterialId);
            stock = _mapper.Map(request, stock);
            await _stockRepository.UpdateAsync(stock!);
            UpdatedStockResponse response = _mapper.Map<UpdatedStockResponse>(stock);
            return response;
        }
    }
}