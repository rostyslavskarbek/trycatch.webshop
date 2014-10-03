using System;
using Newtonsoft.Json;

namespace TryCatch.WebShop.Models.Api.Response
{
    public class Error
    {
        public Error(Int32 code, string errorMessage)
        {
            Code = code;
            Message = errorMessage;
        }

        [JsonProperty("code")]
        public Int32 Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}