using Application.Features.Models.Constants;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Models.Constants.ModelsOperationClaims;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommand : IRequest<CreatedModelResponse>, ISecuredRequest
{
    public string Name { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => new[] { Admin, Write, ModelsOperationClaims.Create };

    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModelRepository _modelRepository;
        private readonly ModelBusinessRules _modelBusinessRules;

        public CreateModelCommandHandler(IMapper mapper, IModelRepository modelRepository,
                                         ModelBusinessRules modelBusinessRules)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
            _modelBusinessRules = modelBusinessRules;
        }

        public async Task<CreatedModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            Model model = _mapper.Map<Model>(request);

            await _modelRepository.AddAsync(model);

            CreatedModelResponse response = _mapper.Map<CreatedModelResponse>(model);
            return response;
        }
    }
}