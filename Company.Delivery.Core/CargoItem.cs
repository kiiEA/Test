namespace Company.Delivery.Core;

public class CargoItem
{
    public Guid Id { get; set; }

    public Guid WaybillId { get; set; }

    public Waybill? Waybill { get; set; }

    // TODO: Уникальное значение в пределах сущности Waybill
    public string Number { get; set; } = null!;

    public string Name { get; set; } = null!;
}