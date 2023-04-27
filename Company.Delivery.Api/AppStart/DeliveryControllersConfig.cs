using Company.Delivery.Api.HttpProtocol;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Company.Delivery.Api.AppStart;

internal static class DeliveryControllersConfig
{
    public static void AddDeliveryControllers(this IServiceCollection services)
    {
        services.AddControllers(mvcOptions => mvcOptions.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer())))
            .AddJsonOptions(jsonOptions =>
            {
                var serializerOptions = jsonOptions.JsonSerializerOptions;

                serializerOptions.Converters.Add(new JsonStringEnumConverter(null, false));
                serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                serializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

        services.Configure<RouteOptions>(routeOptions =>
        {
            routeOptions.LowercaseQueryStrings = true;
            routeOptions.LowercaseUrls = true;
        });
    }
}