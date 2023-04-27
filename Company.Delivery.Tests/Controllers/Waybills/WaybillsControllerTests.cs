using Company.Delivery.Api.Controllers.Waybills.Request;
using Company.Delivery.Api.Controllers.Waybills.Response;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Company.Delivery.Tests.Controllers.Waybills;

public class WaybillsControllerTests : IClassFixture<WaybillsControllerFixture>
{
    private readonly WaybillResponse _waybillResponse;
    private readonly WaybillsControllerFixture _waybillsControllerFixture;

    public WaybillsControllerTests(WaybillsControllerFixture waybillsControllerFixture)
    {
        _waybillResponse = GetResponse();
        _waybillsControllerFixture = waybillsControllerFixture;
    }

    [Fact]
    public async Task GetByIdOkTest()
    {
        var result = await _waybillsControllerFixture.Instance.GetByIdAsync(Guid.Parse("BBB2AFB6-8ECF-4F63-9F98-71C3FC1B5F33"), CancellationToken.None);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var actual = Assert.IsType<WaybillResponse>(okResult.Value);

        Assert.Equivalent(_waybillResponse, actual, true);
    }

    [Fact]
    public async Task GetByIdNotFoundTest()
    {
        var result = await _waybillsControllerFixture.Instance.GetByIdAsync(Guid.Parse("BBB2AFB6-8ECF-4F63-9F98-71C3FC1B5F34"), CancellationToken.None);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task CreateOkTest()
    {
        var result = await _waybillsControllerFixture.Instance.CreateAsync(new WaybillCreateRequest(), CancellationToken.None);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var actual = Assert.IsType<WaybillResponse>(okResult.Value);

        Assert.Equivalent(_waybillResponse, actual, true);
    }

    [Fact]
    public async Task UpdateByIdOkTest()
    {
        var result = await _waybillsControllerFixture.Instance.UpdateByIdAsync(Guid.Parse("BBB2AFB6-8ECF-4F63-9F98-71C3FC1B5F33"),
            new WaybillUpdateRequest(), CancellationToken.None);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var actual = Assert.IsType<WaybillResponse>(okResult.Value);

        Assert.Equivalent(_waybillResponse, actual, true);
    }

    [Fact]
    public async Task UpdateByIdNotFoundTest()
    {
        var result = await _waybillsControllerFixture.Instance.GetByIdAsync(Guid.Parse("BBB2AFB6-8ECF-4F63-9F98-71C3FC1B5F34"), CancellationToken.None);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteByIdTest()
    {
        var result = await _waybillsControllerFixture.Instance.DeleteByIdAsync(Guid.Parse("BBB2AFB6-8ECF-4F63-9F98-71C3FC1B5F33"), CancellationToken.None);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteByIdNotFoundTest()
    {
        var result = await _waybillsControllerFixture.Instance.DeleteByIdAsync(Guid.Parse("BBB2AFB6-8ECF-4F63-9F98-71C3FC1B5F34"), CancellationToken.None);

        Assert.IsType<NotFoundResult>(result);
    }

    private static WaybillResponse GetResponse()
    {
        var waybillId = Guid.Parse("BBB2AFB6-8ECF-4F63-9F98-71C3FC1B5F33");

        return new WaybillResponse
        {
            Id = waybillId,
            Number = "2023-A-1",
            Date = new DateTime(2023, 01, 01),
            Items = new[]
            {
                new CargoItemResponse
                {
                    Id = Guid.Parse("2936A77A-D491-4CFB-8047-A809ACF2AD5E"),
                    WaybillId = waybillId,
                    Number = "2023-A-1/01",
                    Name = "Box"
                },
                new CargoItemResponse
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