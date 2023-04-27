namespace Company.Delivery.Domain.Dto;

public class WaybillCreateDto
{
    public string Number { get; init; } = null!;

    public DateTime Date { get; init; }

    public IEnumerable<CargoItemCreateDto>? Items { get; init; }
}