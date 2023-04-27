namespace Company.Delivery.Api.Controllers.Waybills.Response;

/// <summary>
/// Cargo item
/// </summary>
public class CargoItemResponse
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Waybill Id
    /// </summary>
    public Guid WaybillId { get; init; }

    /// <summary>
    /// Number
    /// </summary>
    public string Number { get; init; } = null!;

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; init; } = null!;
}