using System.Net;

namespace ServiceMan.BaseLibrary.Models
{
    public class BaseErrorDto(HttpStatusCode statusCode, string? message)
    {
        public HttpStatusCode StatusCode { get; set; } = statusCode;

        public string? Message { get; set; } = message;
    }
}