namespace Company.Delivery.Domain.Dto;

public class WaybillDto
{
    public Guid Id { get; init; }

    public string Number { get; init; } = null!;

    public DateTime Date { get; init; }

    public IEnumerable<CargoItemDto>? Items { get; init; }
}