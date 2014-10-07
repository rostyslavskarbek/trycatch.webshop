using System;

namespace TryCatch.WebCore.Logger
{
    public interface IWebShopLogger
    {
        void Error(Exception exception);
    }
}
