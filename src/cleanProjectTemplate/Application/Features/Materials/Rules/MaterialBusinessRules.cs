using Application.Features.Materials.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
namespace Application.Features.Materials.Rules;
public class MaterialBusinessRules : BaseBusinessRules
{
    private readonly IMaterialRepository _materialRepository;
    public MaterialBusinessRules(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }
    public Task MaterialShouldExistWhenSelected(Material? material)
    {
        if (material == null)
            throw new BusinessException(MaterialsBusinessMessages.MaterialNotExists);
        return Task.CompletedTask;
    }
    public async Task MaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Material? material = await _materialRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialShouldExistWhenSelected(material);
    }
}