namespace Company.Delivery.Api.Controllers.Waybills.Request;

/// <summary>
/// Waybill
/// </summary>
public class WaybillUpdateRequest
{
    /// <summary>
    /// Number
    /// </summary>
    public string Number { get; init; } = null!;

    /// <summary>
    /// Date
    /// </summary>
    public DateTime Date { get; init; }

    /// <summary>
    /// Items
    /// </summary>
    public IEnumerable<CargoItemUpdateRequest>? Items { get; init; }
}