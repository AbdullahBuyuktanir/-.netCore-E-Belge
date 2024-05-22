using Core.Utilities.ResultModel.Results;
using Core.Utilities.Results;
using E_Belge.Business.Constants;
using System.Text.Json;

namespace E_Belge.API.Middlewares;

public class ExceptionHandlerMiddleware
{
  private readonly RequestDelegate _next;

  public ExceptionHandlerMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task Invoke(HttpContext context)
  {
    try
    {
      await _next.Invoke(context);
    }
    catch (Exception ex)
    {
      context.Response.StatusCode = StatusCodes.Status500InternalServerError;
      Result result = Result.Failure(Messages.InternalServerError, new Error("Server_Error", ex.Message));

      await context.Response.WriteAsJsonAsync(result);
    }
  }
}
