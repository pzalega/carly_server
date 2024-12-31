using System.Net;

namespace Carly.Shared.Abstractions.Exceptions
{
    public record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}
