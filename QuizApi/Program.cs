using AspNetCoreRateLimit;
using NLog;
using QuizApi.Configuration;
using QuizApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services
    .AddCaching()
    .AddApplication()
    .AddPresentation()
    .AddDatabase(builder.Configuration)
    .AddManagers()
    .AddMiddlewares()
    .AddRateLimiting();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
