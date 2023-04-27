namespace Company.Delivery.Domain.Dto;

public class WaybillUpdateDto
{
    public string Number { get; init; } = null!;

    public DateTime Date { get; init; }

    public IEnumerable<CargoItemUpdateDto>? Items { get; init; }
}