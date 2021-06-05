using System.Collections.Generic;

namespace Application.ResponseHandlers
{
    public class ApiResponseWithData<T> : IApiResponse
    {
        public ApiResponseWithData(int statusCode, T data, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Data = data;
        }

        public int StatusCode { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        
        public string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                // From Wiki ： https://zh.wikipedia.org/wiki/HTTP%E7%8A%B6%E6%80%81%E7%A0%81
                400 => "由於明顯的客戶端錯誤（例如，格式錯誤的請求語法，太大的大小，無效的請求訊息或欺騙性路由請求），伺服器不能或不會處理該請求。",
                401 => "類似於403 Forbidden，401語意即「未認證」，即使用者沒有必要的憑據。",
                404 => "請求失敗，請求所希望得到的資源未被在伺服器上發現，但允許使用者的後續請求。",
                500 => "通用錯誤訊息，伺服器遇到了一個未曾預料的狀況，導致了它無法完成對請求的處理。沒有給出具體錯誤資訊。",
                _ => null
            };
        }
    }
}