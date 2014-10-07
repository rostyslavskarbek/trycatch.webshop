using System.Web.Mvc;
using TryCatch.WebShop.Filters;

namespace TryCatch.WebShop.Controllers
{
    [WebCustomExceptionFilter]
    public class WebControllerBase : Controller
    {
    }
}