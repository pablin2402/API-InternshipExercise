using System;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using BusinessLogic.Exception;


namespace Controllers.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleError(httpContext, ex);
            }
        }

        private static int getCode(Exception ex)
        {

            int code = 500;
            //Agarra el tipo de exception 
            if (ex.GetType() == typeof(EmptyOrNullStatus))
                code = ((EmptyOrNullStatus)ex).Code;
            if (ex.GetType() == typeof(EmptyOrNullId))
                code = ((EmptyOrNullId)ex).Code;
            if (ex.GetType() == typeof(EmptyOrNullName))
                code = ((EmptyOrNullName)ex).Code;

            return code;
        }
        private static Task HandleError(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var errorObj = new
            {
                code = getCode(ex),
                message = ex.Message
            };

            string jsonObj = JsonConvert.SerializeObject(errorObj);
            context.Response.StatusCode = getCode(ex);
            return context.Response.WriteAsync(jsonObj);
        }
    }
    //Agarra y tener el middleware como parte de config
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}