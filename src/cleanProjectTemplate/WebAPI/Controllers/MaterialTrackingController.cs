using Application.Features.Materials.Commands.Create;
using Application.Features.Materials.Commands.Delete;
using Application.Features.Materials.Commands.Update;
using Application.Features.Materials.Queries.GetById;
using Application.Features.Materials.Queries.GetList;
using Application.Features.MaterialTracking.Queries.GetList;
using Application.Features.Models.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialTrackingController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        List<GetListMaterialTrackingListItemDto> response = await Mediator.Send(new GetListMaterialTrackingQuery());
        return Ok(response);
    }
}