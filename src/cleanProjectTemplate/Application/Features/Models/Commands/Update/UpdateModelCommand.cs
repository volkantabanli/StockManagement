using Application.Features.Models.Constants;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Models.Constants.ModelsOperationClaims;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommand : IRequest<UpdatedModelResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => new[] { Admin, Write, ModelsOperationClaims.Update };

    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdatedModelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModelRepository _modelRepository;
        private readonly ModelBusinessRules _modelBusinessRules;

        public UpdateModelCommandHandler(IMapper mapper, IModelRepository modelRepository,
                                         ModelBusinessRules modelBusinessRules)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
            _modelBusinessRules = modelBusinessRules;
        }

        public async Task<UpdatedModelResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            Model? model = await _modelRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _modelBusinessRules.ModelShouldExistWhenSelected(model);
            model = _mapper.Map(request, model);

            await _modelRepository.UpdateAsync(model!);

            UpdatedModelResponse response = _mapper.Map<UpdatedModelResponse>(model);
            return response;
        }
    }
}