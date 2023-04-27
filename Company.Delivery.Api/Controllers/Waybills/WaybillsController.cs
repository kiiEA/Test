using Company.Delivery.Api.Controllers.Waybills.Request;
using Company.Delivery.Api.Controllers.Waybills.Response;
using Company.Delivery.Core;
using Company.Delivery.Domain;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.ObjectModel;
using Company.Delivery.Domain.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Company.Delivery.Api.Controllers.Waybills;

/// <summary>
/// Waybills management
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WaybillsController : ControllerBase
{
    private readonly IWaybillService _waybillService;

    /// <summary>
    /// Waybills management
    /// </summary>
    public WaybillsController(IWaybillService waybillService) => _waybillService = waybillService;

    /// <summary>
    /// Получение Waybill
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _waybillService.GetByIdAsync(id, cancellationToken);
            var response = cast(result);
            return Ok(response);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Создание Waybill
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] WaybillCreateRequest request, CancellationToken cancellationToken)
    {
        var dto = new WaybillCreateDto
        {
            Date = request.Date,
            Items = request.Items as IEnumerable<CargoItemCreateDto>,
            Number = request.Number,
        };

        var result = await _waybillService.CreateAsync(dto, cancellationToken);
        var response = cast(result);
        return Ok(response);
    }
    private WaybillResponse cast(WaybillDto dto) => new WaybillResponse { Id = dto.Id, Date = dto.Date, Items = map(dto.Items), Number = dto.Number };
    private static IEnumerable<CargoItemResponse> map(IEnumerable<CargoItemDto>? items)
    {
        if (items != null)
        {
            for (int i = 0; i < items.ToList().Count; i++)
            {
                yield return new CargoItemResponse
                {
                    Id = items.ToList()[i].Id,
                    Name = items.ToList()[i].Name,
                    Number = items.ToList()[i].Number,
                    WaybillId = items.ToList()[i].WaybillId,
                };
            }
        }

    }
    private WaybillUpdateDto cast(WaybillUpdateRequest dto) => new WaybillUpdateDto { Date = dto.Date, Items = dto.Items as IEnumerable<CargoItemUpdateDto>, Number = dto.Number };
    /// <summary>
    /// Редактирование Waybill
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateByIdAsync(Guid id, [FromBody] WaybillUpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _waybillService.UpdateByIdAsync(id, cast(request), cancellationToken);
            return Ok(cast(result));
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Удаление Waybill
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _waybillService.DeleteByIdAsync(id, cancellationToken);
            return Ok();
        }
        catch (Exception)
        {
            return NotFound();
        }

    }
}