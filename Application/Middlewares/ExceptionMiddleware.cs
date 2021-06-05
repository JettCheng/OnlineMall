using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Application.ResponseHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;                 
        private readonly ILogger<ExceptionMiddleware> _logger;  
        private readonly IHostEnvironment _env;                 
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try // 如果無異常則系統進行下一步
            {
                
                await _next(context);
            }
            catch (Exception ex) // 如果 catch 到 error
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                // 統整 Response 並儲存成 ApiException 格式，如果是開發環境
                var response = _env.IsDevelopment()
                    // 則顯示 StatusCode、錯誤訊息、Trace
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    // 否則只顯示 StatusCode
                    : new ApiException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                
                // 存成Json，設定成 CamelCase
                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}