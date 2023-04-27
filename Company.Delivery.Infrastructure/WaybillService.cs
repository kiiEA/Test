using Company.Delivery.Core;
using Company.Delivery.Database;
using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Company.Delivery.Infrastructure;

public class WaybillService : IWaybillService
{
    private DeliveryDbContext DbContext { get; set; }

    public WaybillService(DeliveryDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public async Task<WaybillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        using (var db = DbContext)
        {
            var wayBill = await DbContext.Waybills.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (wayBill != null)
            {
                var dto = new WaybillDto()
                {
                    Id = wayBill.Id,
                    Number = wayBill.Number,
                    Date = wayBill.Date,
                    Items = wayBill.Items as IEnumerable<CargoItemDto>,
                };
                return dto;
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

    }

    public async Task<WaybillDto> CreateAsync(WaybillCreateDto data, CancellationToken cancellationToken)
    {
        using (var db = DbContext)
        {
            var dto = new Waybill
            {
                Date = data.Date,
                Items = data.Items as Collection<CargoItem>,
                Number = data.Number,
            };
            var bill = await DbContext.Waybills.AddAsync(dto, cancellationToken);
            var wayDto = new WaybillDto()
            {
                Id = bill.Entity.Id,
                Number = bill.Entity.Number,
                Date = bill.Entity.Date,
                Items = bill.Entity.Items as IEnumerable<CargoItemDto>,
            };
            await DbContext.SaveChangesAsync(cancellationToken);
            return wayDto;
        }

    }

    public async Task<WaybillDto> UpdateByIdAsync(Guid id, WaybillUpdateDto data, CancellationToken cancellationToken)
    {
        using (var db = DbContext)
        {
            var dto = new Waybill
            {
                Date = data.Date,
                Items = data.Items as Collection<CargoItem>,
                Number = data.Number,
            };

            var result = DbContext.Waybills.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Number = data.Number;
                result.Date = data.Date;
                result.Items = data.Items as Collection<CargoItem>;
                await db.SaveChangesAsync(cancellationToken);

                var wayDto = new WaybillDto()
                {
                    Id = result.Id,
                    Number = result.Number,
                    Date = result.Date,
                    Items = result.Items as IEnumerable<CargoItemDto>,
                };
                return wayDto;
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }
    }

    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        using (var db = DbContext)
        {
            var result = DbContext.Waybills.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                db.Waybills.Remove(result);
                db.SaveChanges();
                return Task.CompletedTask;
            }
            else
            { throw new EntityNotFoundException(); }
        }

    }
}