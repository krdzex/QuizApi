using Contracts;
using MediatR;
using System.Diagnostics;

namespace Application.Behaviors;
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
{
    private readonly ILoggerManager _loggerManager;

    public LoggingBehavior(ILoggerManager loggerManager)
    {
        _loggerManager = loggerManager;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var timeBeforeReuqest = DateTime.UtcNow;

        _loggerManager.LogInfo($"Starting request {requestName},{timeBeforeReuqest}");

        var timer = new Stopwatch();
        timer.Start();
        var result = await next();
        timer.Stop();

        var timeAfterRequest = DateTime.UtcNow;

        _loggerManager.LogInfo($"Completed request {requestName}, {timeAfterRequest}, total request time:{timer.ElapsedMilliseconds}");

        return result;
    }
}