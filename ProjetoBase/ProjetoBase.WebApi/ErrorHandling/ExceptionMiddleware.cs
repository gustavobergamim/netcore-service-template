using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProjetoBase.Domain.Messages;
using ProjetoBase.WebApi.Controllers;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using static System.String;

namespace ProjetoBase.WebApi.ErrorHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IWebHostEnvironment _hosting;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IWebHostEnvironment hosting)
        {
            _loggerFactory = loggerFactory;
            _hosting = hosting;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                if (_hosting.IsDevelopment())
                {
                    throw;
                }

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var logger = _loggerFactory.CreateLogger<ApiController>();
            var errorId = Guid.NewGuid();
            logger.LogError(exception, $"Erro {errorId}: {exception}");

            if (context.Response.HasStarted)
            {
                return;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var details = new ErrorDetails(context.Response.StatusCode,
                Format(ErrorMessages.InternalServerError, errorId));
            await context.Response.WriteAsync(details);
        }
    }
}
