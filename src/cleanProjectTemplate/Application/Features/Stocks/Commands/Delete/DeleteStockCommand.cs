using Application.Features.Stocks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Stocks.Commands.Delete;

public class DeleteStockCommand : IRequest<DeletedStockResponse>
{
    public Guid Id { get; set; }
    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand, DeletedStockResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly StockBusinessRules _stockBusinessRules;

        public DeleteStockCommandHandler(IMapper mapper, IStockRepository stockRepository,
                                         StockBusinessRules stockBusinessRules)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _stockBusinessRules = stockBusinessRules;
        }

        public async Task<DeletedStockResponse> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            Stock? stock = await _stockRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _stockBusinessRules.StockShouldExistWhenSelected(stock);

            await _stockRepository.DeleteAsync(stock!);

            DeletedStockResponse response = _mapper.Map<DeletedStockResponse>(stock);
            return response;
        }
    }
}