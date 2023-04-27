using Company.Delivery.Domain.Dto;

namespace Company.Delivery.Domain;

public interface IWaybillService
{
    Task<WaybillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<WaybillDto> CreateAsync(WaybillCreateDto data, CancellationToken cancellationToken);

    Task<WaybillDto> UpdateByIdAsync(Guid id, WaybillUpdateDto data, CancellationToken cancellationToken);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}