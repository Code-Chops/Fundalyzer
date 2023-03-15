﻿using System.Net;
using Fundalyzer.Infrastructure.Api.Exceptions;

namespace Fundalyzer.Infrastructure.Api.Configuration;

/// <summary>
/// Will throw an <see cref="TooManyRequestsException"/> if a rate limit is encountered.
/// </summary>
public sealed class ThrowExceptionRateLimitingStrategy : IRateLimitingStrategy
{
    /// <inheritdoc />
    /// <exception cref="TooManyRequestsException"></exception>
    public async Task<RestResponse> ExecuteAsync(Func<Task<RestResponse>> action)
    {
        var response = await action();

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
            throw new TooManyRequestsException();

        return response;
    }
}