using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.API.Helpers.Shared;

namespace Shared.API.Helpers.Middleware
{
     /// <summary>
    /// Middleware to handle all requests and Exceptions
    /// </summary>
    public class HrSharedRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public HrSharedRequestMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("Shared  API");
        }
        /// <summary>
        /// Process the Request and Catch Exceptions
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            var eventId = DateTime.UtcNow.Ticks.ToString();
            var actionContext = new ActionContext { HttpContext = context };
            try
            {
                await _next(context);
                sw.Stop();
                var logMessage = GetRequestResponseData(context, sw.ElapsedMilliseconds);
                _logger.LogInformation(new EventId(0, eventId), logMessage);
            }
            catch (ShredValidationException  ve)
            {
                var response = new SharedResponseResult<object>(null, System.Net.HttpStatusCode.BadRequest, ve.Notify, ve.Messages);
                await response.ExecuteResultAsync(actionContext);
                sw.Stop();
                var logMessage = GetRequestResponseData(context, sw.ElapsedMilliseconds);
                _logger.LogWarning(new EventId(0, eventId), logMessage);
            }
            catch (ShredBadRequestException be)
            {
                var response = new SharedResponseResult<object>(null, System.Net.HttpStatusCode.BadRequest, be.Notify, be.Messages);
                await response.ExecuteResultAsync(actionContext);
                sw.Stop();
                var logMessage = GetRequestResponseData(context, sw.ElapsedMilliseconds);
                _logger.LogWarning(new EventId(0, eventId), logMessage);
            }
            catch (SharedAuthorizationException ae)
            {
                var response = new SharedResponseResult<object>(null, System.Net.HttpStatusCode.Forbidden, true, ae.Messages);
                await response.ExecuteResultAsync(actionContext);
                sw.Stop();
                var logMessage = GetRequestResponseData(context, sw.ElapsedMilliseconds);
                _logger.LogError(new EventId(0, eventId), logMessage);
            }
            catch (SharedAuthenticationException ae)
            {
                var response = new SharedResponseResult<object>(null, System.Net.HttpStatusCode.Unauthorized, true, ae.Messages);
                await response.ExecuteResultAsync(actionContext);
                sw.Stop();
                var logMessage = GetRequestResponseData(context, sw.ElapsedMilliseconds);
                _logger.LogError(new EventId(0, eventId), logMessage);
            }
            catch (Exception e)
            {
                var message = $"Unknown Exception Please Check Log {eventId}";
                var response = new SharedResponseResult<object>(null, System.Net.HttpStatusCode.InternalServerError, true, message);
                await response.ExecuteResultAsync(actionContext);
                sw.Stop();
                var logMessage = GetRequestResponseData(context, sw.ElapsedMilliseconds);
                _logger.LogCritical(new EventId(0, eventId), e, logMessage);
            }
        }

        private string GetRequestResponseData(HttpContext context, long elapsedMilliseconds)
        {
            var request = context.Request;
            var response = context.Response;
            var requestLogMessage = $"{DateTime.UtcNow:s}\nREQUEST:\n{request.Method} - {request.Path.Value}{request.QueryString}";
            requestLogMessage += $"\nContentType: {request.ContentType ?? "Not specified"}";
            requestLogMessage += $"\nHost: {request.Host}";
            requestLogMessage += $"\nRESPONSE:\nStatus Code: {response.StatusCode}";
            requestLogMessage += $"\nRequestTime: {elapsedMilliseconds}";
            return requestLogMessage;
        }
    }
}
