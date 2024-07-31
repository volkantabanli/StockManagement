using Application.Features.Stocks.Commands.Create;
using Application.Features.Stocks.Commands.Delete;
using Application.Features.Stocks.Commands.Update;
using Application.Features.Stocks.Queries.GetById;
using Application.Features.Stocks.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StocksController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStockCommand createStockCommand)
    {
        CreatedStockResponse response = await Mediator.Send(createStockCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStockCommand updateStockCommand)
    {
        UpdatedStockResponse response = await Mediator.Send(updateStockCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStockResponse response = await Mediator.Send(new DeleteStockCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStockResponse response = await Mediator.Send(new GetByIdStockQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStockQuery getListStockQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStockListItemDto> response = await Mediator.Send(getListStockQuery);
        return Ok(response);
    }
}