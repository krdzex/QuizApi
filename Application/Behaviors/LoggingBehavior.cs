using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Behaviors;
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting request {@RequestName},{@DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow
            );

        var timer = new Stopwatch();
        timer.Start();
        var result = await next();
        timer.Stop();

        _logger.LogInformation("Completed request {@RequestName},{@DateTimeUtc}, total request time:{@ResponseTime}",
           typeof(TRequest).Name,
           DateTime.UtcNow,
           timer.ElapsedMilliseconds
           );

        return result;
    }
}