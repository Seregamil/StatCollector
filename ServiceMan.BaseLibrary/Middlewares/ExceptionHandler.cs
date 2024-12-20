using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using ServiceMan.BaseLibrary.Exceptions;
using ServiceMan.BaseLibrary.Extensions;
using ServiceMan.BaseLibrary.Models;

namespace ServiceMan.BaseLibrary.Middlewares;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;

    public ExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (AlreadyExistsException e)
        {
            await WriteResponse(
                httpContext,
                HttpStatusCode.Conflict,
                new BaseResultDto<string>
                {
                    Error = new BaseErrorDto(HttpStatusCode.Conflict, e.Message)
                }
            );
        }
        catch (NotFoundedException e)
        {
            await WriteResponse(
                httpContext,
                HttpStatusCode.NotFound,
                new BaseResultDto<string>
                {
                    Error = new BaseErrorDto(HttpStatusCode.NotFound, e.Message)
                }
            );
        }
        catch (NotSuccessRequest e)
        {
            await WriteResponse(
                httpContext,
                HttpStatusCode.InternalServerError,
                new BaseResultDto<string>
                {
                    Error = new BaseErrorDto(HttpStatusCode.InternalServerError, e.Message)
                }
            );
        }
        catch (Exception e)
        {
            await WriteResponse(
                httpContext,
                HttpStatusCode.InternalServerError,
                new BaseResultDto<string>(new BaseErrorDto(HttpStatusCode.InternalServerError, e.Message))
            );
            Log.Error(e, "InternalServerError");
        }
    }

    private static async Task WriteResponse<T>(HttpContext context, HttpStatusCode httpStatusCode,
        BaseResultDto<T> response)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)httpStatusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response, Json.GetOptions()));
    }
}