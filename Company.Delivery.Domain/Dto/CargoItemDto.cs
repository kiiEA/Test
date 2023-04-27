namespace Company.Delivery.Domain.Dto;

public class CargoItemDto
{
    public Guid Id { get; init; }

    public Guid WaybillId { get; init; }

    public string Number { get; init; } = null!;

    public string Name { get; init; } = null!;
}