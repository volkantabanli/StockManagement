using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
namespace Application.Features.Materials.Queries.GetList;
public class GetListMaterialQuery : IRequest<GetListResponse<GetListMaterialListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListMaterialQueryHandler : IRequestHandler<GetListMaterialQuery, GetListResponse<GetListMaterialListItemDto>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        public GetListMaterialQueryHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListMaterialListItemDto>> Handle(GetListMaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Material> materials = await _materialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );
            GetListResponse<GetListMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialListItemDto>>(materials);
            return response;
        }
    }
}