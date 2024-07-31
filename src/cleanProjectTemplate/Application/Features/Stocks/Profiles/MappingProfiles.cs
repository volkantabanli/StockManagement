using Application.Features.Stocks.Commands.Create;
using Application.Features.Stocks.Commands.Delete;
using Application.Features.Stocks.Commands.Update;
using Application.Features.Stocks.Queries.GetById;
using Application.Features.Stocks.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Stocks.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Stock, CreateStockCommand>().ReverseMap();
        CreateMap<Stock, CreatedStockResponse>().ReverseMap();
        CreateMap<Stock, UpdateStockCommand>().ReverseMap();
        CreateMap<Stock, UpdatedStockResponse>().ReverseMap();
        CreateMap<Stock, DeleteStockCommand>().ReverseMap();
        CreateMap<Stock, DeletedStockResponse>().ReverseMap();
        CreateMap<Stock, GetByIdStockResponse>().ReverseMap();
        CreateMap<Stock, GetListStockListItemDto>().ReverseMap();
        CreateMap<IPaginate<Stock>, GetListResponse<GetListStockListItemDto>>().ReverseMap();
    }
}