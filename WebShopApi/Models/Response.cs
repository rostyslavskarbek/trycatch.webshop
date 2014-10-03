using TryCatch.WebCore.Enum;

namespace WebShopApi.Models
{
    public class Response
    {
        public ResponseStatus Status { get; set; }
        public object Data { get; set; } 
    }
}