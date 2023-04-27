namespace Company.Delivery.Api.Controllers.Waybills.Request;

/// <summary>
/// Cargo item
/// </summary>
public class CargoItemCreateRequest
{
    /// <summary>
    /// Number
    /// </summary>
    public string Number { get; init; } = null!;

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; init; } = null!;
}