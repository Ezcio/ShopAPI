using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sklep.Exceptions;
using System;
using System.Threading.Tasks;

namespace Sklep.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        async public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (NullOrEmptyException nullOrEmptyException)
            {
                context.Response.StatusCode = 400;               
            }
            catch (AlreadyExistsException alreadyExistsException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(alreadyExistsException.Message);

            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
                
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
