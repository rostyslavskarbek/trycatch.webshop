using TryCatch.Dto;

namespace TryCatch.Services
{
    public interface ICheckoutService
    {
        void CompleteCheckout(CustomerDto customer);
    }
}
