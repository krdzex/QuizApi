using Application.Behaviors;
using Contracts;
using FluentValidation;
using LoggerService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QuizApi.Middleware;
using Repository;

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

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(opts =>
        {
            opts.UseNpgsql(configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
        });

        return services;
    }

    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddSingleton<ILoggerManager, LoggerManager>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Application.AssemblyReference).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(DbSaveBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(
            typeof(Application.AssemblyReference).Assembly,
            includeInternalTypes: true);

        return services;
    }

    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        services.AddTransient<GlobalExceptionHandlerMiddleware>();

        return services;
    }
}
