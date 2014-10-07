using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;
using TryCatch.WebCore.Logger;
using TryCatch.WebShop.Models.Api.Response;


namespace TryCatch.WebShop.Filters
{
    public class ApiCustomExceptionFilterAttribute : IAutofacExceptionFilter
    {
        private readonly IWebShopLogger _logger;

        public ApiCustomExceptionFilterAttribute(IWebShopLogger logger)
        {
            _logger = logger;
        }

        public void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;
            if (exception != null)
            {
                _logger.Error(exception);
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                                                          HttpStatusCode.OK,
                                                          RestResponse.Failed("Sorry, something went wrong."));

            }
        }
    }
}