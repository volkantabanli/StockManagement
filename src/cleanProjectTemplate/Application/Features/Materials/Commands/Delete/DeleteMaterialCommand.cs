using Application.Features.Materials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
namespace Application.Features.Materials.Commands.Delete;
public class DeleteMaterialCommand : IRequest<DeletedMaterialResponse>
{
    public Guid Id { get; set; }
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, DeletedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;
        private readonly MaterialBusinessRules _materialBusinessRules;
        public DeleteMaterialCommandHandler(IMapper mapper, IMaterialRepository materialRepository,
                                         MaterialBusinessRules materialBusinessRules)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialBusinessRules = materialBusinessRules;
        }
        public async Task<DeletedMaterialResponse> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            Material? material = await _materialRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _materialBusinessRules.MaterialShouldExistWhenSelected(material);
            await _materialRepository.DeleteAsync(material!);
            DeletedMaterialResponse response = _mapper.Map<DeletedMaterialResponse>(material);
            return response;
        }
    }
}