using Microsoft.OpenApi.Models;

namespace QuizApi.Configuration;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers(config =>
        {
            config.RespectBrowserAcceptHeader = true;
            config.ReturnHttpNotAcceptable = true;
        }).AddXmlDataContractSerializerFormatters()
          .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo { Title = "QuizApi", Version = "v1" });
        });

        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();

        return services;
    }
}
