using System;
using Newtonsoft.Json;
using TryCatch.WebCore.Enum;

namespace TryCatch.WebShop.Models.Api.Response
{
    public class RestResponse
    {
        [JsonProperty("status")]
        public ResponseStatus Status { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        public static RestResponse Ok(object data)
        {
            return new RestResponse
            {
                Status = ResponseStatus.Success,
                Data = data
            };
        }

        public static RestResponse Failed(string errorMessage, Int32 code = 1)
        {
            return new RestResponse
            {
                Status = ResponseStatus.Failed,
                Error = new Error(code, errorMessage)
            };
        }
    }
}