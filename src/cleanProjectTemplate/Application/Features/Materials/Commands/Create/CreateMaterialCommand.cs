using Application.Features.Materials.Constants;
using Application.Features.Materials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using static Application.Features.Materials.Constants.MaterialsOperationClaims;

namespace Application.Features.Materials.Commands.Create;

public class CreateMaterialCommand : IRequest<CreatedMaterialResponse>, ISecuredRequest
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string? Engine { get; set; }
    public string? Year { get; set; }
    public double Price { get; set; }
    public string[] Roles => new[] { Admin, Write, MaterialsOperationClaims.Create };
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, CreatedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;
        private readonly MaterialBusinessRules _materialBusinessRules;
        public CreateMaterialCommandHandler(IMapper mapper, IMaterialRepository materialRepository,
                                         MaterialBusinessRules materialBusinessRules)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialBusinessRules = materialBusinessRules;
        }
        public async Task<CreatedMaterialResponse> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            Material material = _mapper.Map<Material>(request);
            await _materialRepository.AddAsync(material);
            CreatedMaterialResponse response = _mapper.Map<CreatedMaterialResponse>(material);
            return response;
        }
    }
}