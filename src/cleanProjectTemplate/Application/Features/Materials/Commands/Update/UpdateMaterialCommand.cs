using Application.Features.Materials.Constants;
using Application.Features.Materials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Materials.Constants.MaterialsOperationClaims;

namespace Application.Features.Materials.Commands.Update;

public class UpdateMaterialCommand : IRequest<UpdatedMaterialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Engine { get; set; }
    public string Year { get; set; }
    public double Price { get; set; }
    public string[] Roles => new[] { Admin, Write, MaterialsOperationClaims.Update };
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, UpdatedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;
        private readonly MaterialBusinessRules _materialBusinessRules;

        public UpdateMaterialCommandHandler(IMapper mapper, IMaterialRepository materialRepository,
                                         MaterialBusinessRules materialBusinessRules)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialBusinessRules = materialBusinessRules;
        }
        public async Task<UpdatedMaterialResponse> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            Material? material = await _materialRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _materialBusinessRules.MaterialShouldExistWhenSelected(material);
            material = _mapper.Map(request, material);
            await _materialRepository.UpdateAsync(material!);
            UpdatedMaterialResponse response = _mapper.Map<UpdatedMaterialResponse>(material);
            return response;
        }
    }
}