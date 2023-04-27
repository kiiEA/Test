using Company.Delivery.Core;
using Company.Delivery.Database.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Company.Delivery.Database;

public class DeliveryDbContext : DbContext
{
    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options) { }

    public DbSet<CargoItem> CargoItems { get; protected init; } = null!;

    public DbSet<Waybill> Waybills { get; protected init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Waybill>()
            .HasIndex(w => w.Number)
            .IsUnique();

        modelBuilder.Entity<CargoItem>()
            .HasIndex(c => c.Number)
            .IsUnique();
        modelBuilder.ApplyConfiguration(new CargoItemConfiguration());
        modelBuilder.ApplyConfiguration(new WaybillConfiguration());
        // TODO: регистрация всех реализаций IEntityTypeConfiguration в сборке Company.Delivery.Database
    }
}