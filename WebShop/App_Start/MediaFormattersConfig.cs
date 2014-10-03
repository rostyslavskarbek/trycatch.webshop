using System.Net.Http.Headers;
using System.Web.Http;

namespace TryCatch.WebShop.App_Start
{
    public class MediaFormattersConfig
    {
        public static void Configure()
        {
            GlobalConfiguration.Configuration
                .Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}