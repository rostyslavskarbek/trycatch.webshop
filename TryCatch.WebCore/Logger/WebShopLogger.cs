using System;

namespace TryCatch.WebCore.Logger
{
    public class WebShopLogger:IWebShopLogger
    {
        private readonly NLog.Logger _logger;

        public WebShopLogger()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger(); ;
        }

        public void Error(Exception exception)
        {
            _logger.Error(exception);
        }

        public void Error(string message, Exception exception)
        {
            _logger.Error(message, exception);
        }
    }
}
