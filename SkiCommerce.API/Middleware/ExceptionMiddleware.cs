using System;
using System.Net;
using System.Text.Json;
using SkiCommerce.API.Errors;

namespace SkiCommerce.API.Middleware;

public class ExceptionMiddleware(IHostEnvironment env, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try 
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, env);
        }
    }

    /// <summary>
    /// This function will handle the exception and return a JSON response
    /// to the client with the error message and status code
    /// </summary>
    /// <param name="context"> Status Code error context </param>
    /// <param name="ex"> Exception Message </param>
    /// <param name="env"> Enviroment </param>
    /// <returns></returns>
    private static Task HandleExceptionAsync(HttpContext context, Exception ex, IHostEnvironment env)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = env.IsDevelopment()
            ? new ApiErrorResponse(context.Response.StatusCode, ex.Message, ex.StackTrace)
            : new ApiErrorResponse(context.Response.StatusCode, ex.Message, "Internal Server Error");

        // Convert the response object to JSON
        var option = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

        // Serialize the response object to JSON
        var json = JsonSerializer.Serialize(response, option);

        return context.Response.WriteAsync(json);
    }
}
