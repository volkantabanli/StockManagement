using Application.Features.Materials.Commands.Create;
using Application.Features.Materials.Commands.Delete;
using Application.Features.Materials.Commands.Update;
using Application.Features.MaterialTracking.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.MaterialTracking.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //CreateMap<Material, GetListMaterialTrackingListItemDto>().ReverseMap();
        //CreateMap<IPaginate<Material>, GetListResponse<GetListMaterialTrackingListItemDto>>().ReverseMap();
        //CreateMap<Material, GetListMaterialTrackingQuery>().ReverseMap();
    }
}