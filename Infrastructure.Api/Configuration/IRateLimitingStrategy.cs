﻿namespace Fundalyzer.Infrastructure.Api.Configuration;

/// <summary>
/// Defines how rate limiting is handled and it occurs.
/// </summary>
public interface IRateLimitingStrategy
{
    /// <summary>
    /// Handler for HTTPRequests.
    /// </summary>
    /// <param name="action">The function that sends the HTTP Request.</param>
    /// <returns>The response from the Funda API.</returns>
    Task<RestResponse> ExecuteAsync(Func<Task<RestResponse>> action);
}