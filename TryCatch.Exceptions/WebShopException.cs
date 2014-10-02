using System;

namespace TryCatch.Exceptions
{
    public class WebShopException:Exception
    {
        public WebShopException(string message) : base(message)
        {
        }
    }
}
