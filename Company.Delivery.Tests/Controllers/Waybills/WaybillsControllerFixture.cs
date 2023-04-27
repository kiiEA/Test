using Company.Delivery.Api.Controllers.Waybills;
using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;
using Moq;

namespace Company.Delivery.Tests.Controllers.Waybills;

public class WaybillsControllerFixture
{
    public WaybillsControllerFixture()
    {
        var waybillDto = GetByIdDto();
        var waybillService = new Mock<IWaybillService>();

        waybillService.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Guid id, CancellationToken _) => id == waybillDto.Id ? waybillDto : throw new EntityNotFoundException());

        waybillService.Setup(x => x.CreateAsync(It.IsAny<WaybillCreateDto>(), It.IsAny<CancellationToken>())).ReturnsAsync(waybillDto);

        waybillService.Setup(x => x.UpdateByIdAsync(It.IsAny<Guid>(), It.IsAny<WaybillUpdateDto>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Guid id, WaybillUpdateDto _, CancellationToken _) => id == waybillDto.Id ? waybillDto : throw new EntityNotFoundException());

        waybillService.Setup(x => x.DeleteByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .Returns((Guid id, CancellationToken _) => id == waybillDto.Id ? Task.CompletedTask : throw new EntityNotFoundException());

        Instance = new WaybillsController(waybillService.Object);
    }

    public WaybillsController Instance { get; }

    private static WaybillDto GetByIdDto()
    {
        var waybillId = Guid.Parse("BBB2AFB6-8ECF-4F63-9F98-71C3FC1B5F33");

        return new WaybillDto
        {
            Id = waybillId,
            Number = "2023-A-1",
            Date = new DateTime(2023, 01, 01),
            Items = new[]
            {
                new CargoItemDto
                {
                    Id = Guid.Parse("2936A77A-D491-4CFB-8047-A809ACF2AD5E"),
                    WaybillId = waybillId,
                    Number = "2023-A-1/01",
                    Name = "Box"
                },
                new CargoItemDto
                {
                    Id = Guid.Parse("FEA616D3-75B1-49C7-86CE-65107BFE3DFC"),
                    WaybillId = waybillId,
                    Number = "2023-A-1/02",
                    Name = "Pallet"
                }
            }
        };
    }
}