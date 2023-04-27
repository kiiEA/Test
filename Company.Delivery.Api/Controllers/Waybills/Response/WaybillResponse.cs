namespace Company.Delivery.Api.Controllers.Waybills.Response;

/// <summary>
/// Waybill
/// </summary>
public class WaybillResponse
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

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
    public IEnumerable<CargoItemResponse>? Items { get; init; }
}