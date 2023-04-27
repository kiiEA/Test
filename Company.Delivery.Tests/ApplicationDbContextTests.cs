using Company.Delivery.Database;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Company.Delivery.Tests;

public class ApplicationDbContextTests
{
    [Fact]
    public void StringPropertiesHasMaxLength()
    {
        var options = new DbContextOptionsBuilder<DeliveryDbContext>().UseInMemoryDatabase(Database.Database.Name).Options;
        using var dbContext = new DeliveryDbContext(options);

        var stringType = typeof(string);

        var properties = dbContext.Model.GetEntityTypes()
            .SelectMany(x => x.GetProperties()
                .Where(p => p.ClrType == stringType && !p.GetMaxLength().HasValue)
                .Select(p => x.Name + " -> " + p.Name))
            .ToArray();

        if (!properties.Any())
            return;

        var message = $"Следующие строковые свойства ({properties.Length} шт.) не имеют ограничений на длину:" + Environment.NewLine + string.Join(Environment.NewLine,
            properties);

        Assert.Fail(message);
    }
}