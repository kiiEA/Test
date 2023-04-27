using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Delivery.Database.ModelConfigurations;

internal class CargoItemConfiguration : IEntityTypeConfiguration<CargoItem>
{
    public void Configure(EntityTypeBuilder<CargoItem> builder)
    {
        builder.Property(p => p.Number).IsRequired().HasMaxLength(30);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        // TODO: все строковые свойства должны иметь ограничение на длину
        // TODO: должно быть ограничение на уникальность свойства CargoItem.Number в пределах одной сущности Waybill
        // TODO: ApplicationDbContextTests должен выполняться без ошибок
    }
}