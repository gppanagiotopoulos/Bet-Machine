using BetMachine.Domain.Models.Response;
using Newtonsoft.Json;

namespace BetMachine.Helpers
{
    /// <summary>
    /// Middleware Handler for all exceptions.
    /// </summary>
    public class ExceptionHandlerMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                //process request
                await next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var message = JsonConvert.SerializeObject(new ServiceResponse<string?>
                {
                    Data = null,
                    Success = false,
                    Messages =
                    {
                        new MessageResponse
                        {
                            Code = 3000,
                            Message = "Unhandled exception. Please contact support.",
                            ExtraDescription = exception.Message
                        }
                    }
                });
                response.StatusCode = StatusCodes.Status500InternalServerError;
                await response.WriteAsync(message);
            }
        }
    }
}