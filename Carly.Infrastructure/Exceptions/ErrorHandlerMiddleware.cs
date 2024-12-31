using Carly.Shared.Abstractions.Exceptions;
using Carly.Shared.Exceptions;
using Humanizer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Carly.Infrastructure.Exceptions
{
    internal class ProblemExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ProblemExceptionHandler> _logger;
        private readonly IProblemDetailsService _problemDetailsService;
        private static readonly ConcurrentDictionary<Type, string> ExceptionCodes = new();

        public ProblemExceptionHandler(ILogger<ProblemExceptionHandler> logger, IProblemDetailsService problemDetailsService)
        {
            _logger = logger;
            _problemDetailsService = problemDetailsService;
        }

        private static string GetErrorCode(object exception)
        {
            var type = exception.GetType();
            return ExceptionCodes.GetOrAdd(type, type.Name.Underscore().Replace("_exception", string.Empty));
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);

            var mappedException = exception switch
            {
                DomainException domainException => 
                    new ExceptionResponse(new ErrorResponse(new Error(GetErrorCode(exception), exception.Message)), HttpStatusCode.UnprocessableEntity),
                BadHttpRequestException badRequestException => 
                    new ExceptionResponse(new ErrorResponse(new Error(GetErrorCode(exception), exception.Message)), (HttpStatusCode)badRequestException.StatusCode),
                ValidationException validationException => 
                    new ExceptionResponse(new ErrorResponse(new Error(GetErrorCode(exception), exception.Message)), HttpStatusCode.BadRequest),
                FluentValidation.ValidationException fluentValidationException => 
                    new ExceptionResponse(new ErrorResponse(fluentValidationException.Errors.Select(x=>new Error(x.ErrorCode, x.ErrorMessage)).ToArray()), HttpStatusCode.UnprocessableEntity),
                _ => 
                    new ExceptionResponse(new ErrorResponse(new Error(GetErrorCode(exception), exception.Message)), HttpStatusCode.InternalServerError)
            };

            var statusCode = (int)(mappedException?.StatusCode ?? HttpStatusCode.InternalServerError);
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = exception.GetType().Name.Underscore(),
                Detail = exception.Message,
                Type = exception?.GetType().Name.Underscore(),
            };
            problemDetails.Extensions["errors"] = (mappedException.Response as ErrorResponse)?.errors;

            httpContext.Response.StatusCode = statusCode;
            return await _problemDetailsService.TryWriteAsync(
                new ProblemDetailsContext
                {
                    HttpContext = httpContext,
                    ProblemDetails = problemDetails
                });
        }

        private record Error(string Code, string Message);
        private record ErrorResponse(params Error[] errors);
    }
}
