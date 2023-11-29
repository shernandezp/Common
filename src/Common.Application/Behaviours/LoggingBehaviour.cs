﻿using Common.Application.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Common.Application.Behaviours;

public class LoggingBehaviour<TRequest>(ILogger<TRequest> logger, IUser user, IIdentityService identityService) : IRequestPreProcessor<TRequest> where TRequest : notnull
{

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = user.Id ?? string.Empty;
        string? userName = string.Empty;

        if (!string.IsNullOrEmpty(userId))
        {
            userName = identityService.GetUserNameAsync(userId);
        }

        logger.LogInformation("ReThinkMarket Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request);
        return Task.CompletedTask;
    }
}