using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApi.Helpers.ReturnMessage;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Helper.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ExceptionMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            StringBuilder err = new StringBuilder();
            err.Append($"User ID : 0");
            err.Append("<br/>");
            err.Append("<br/>");
            err.Append($"Ip Number : {this.httpContextAccessor.HttpContext.Response.HttpContext.Connection.RemoteIpAddress}");
            err.Append("<hr><br/>");
            err.Append(ex.Message);
            err.Append("<hr><br/>");
            err.Append(ex.StackTrace);
            err.Append("<hr><br/>");
            foreach (var item in this.httpContextAccessor.HttpContext.Request.Headers)
            {
                err.Append($"{item.Key} - {item.Value}<br/>");
            }
            err.Append("<br/><hr><br/>");
            foreach (var item in httpContextAccessor.HttpContext.Request.Query)
            {
                err.Append($"{item.Key} - {item.Value}<br/>");
            }
            err.Append("<br/><hr><br/>");
            try
            {
                foreach (var item in httpContextAccessor.HttpContext.Request.Form)
                {
                    err.Append($"{item.Key} - {item.Value}<br/>");
                }
            }
            catch { }

            //
            // _emailHelp.Basic(new EmailHelpDTO.Request { EmailTo = _configHelp.ErrorMailAddress, Subject = $"{_configHelp.DomainName} Hata Oluştu [# { DateTime.Now.ToString() } ]", Content = err.ToString() });

            //
            err.Clear();

            //
            var InnerException = "";
            if (ex.InnerException != null)
                InnerException = ex.InnerException.Message; 

            //
            var json = JsonConvert.SerializeObject((new ReturnError { InternalMessage = InnerException, Message = ex.Message }));
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(json);
        }
    }
}
