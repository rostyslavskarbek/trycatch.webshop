using System.Web.Mvc;
using TryCatch.WebCore.Logger;

namespace TryCatch.WebShop.Filters
{
    public class WebCustomExceptionFilterAttribute : HandleErrorAttribute
    {
        public IWebShopLogger Logger { get; set; }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                Logger.Error(filterContext.Exception);
            }

            base.OnException(filterContext);
        }
    }
}