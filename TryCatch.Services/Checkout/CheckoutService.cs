using System.Linq;
using AutoMapper;
using TryCatch.Dal.Entities;
using TryCatch.Dto;
using TryCatch.Exceptions;
using TryCatch.Repositories.UnitOfWork;
using TryCatch.Services.ShoppingCart;

namespace TryCatch.Services
{
    public class CheckoutService: ICheckoutService
    {
        private const decimal Vat = 0.18M;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IUnitOfWork _unitOfWork;

        public CheckoutService(IShoppingCartService shoppingCartService, IUnitOfWork unitOfWork)
        {
            _shoppingCartService = shoppingCartService;
            _unitOfWork = unitOfWork;
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }

        public void CompleteCheckout(CustomerDto customer)
        {
            var shoppingCart = _shoppingCartService.GetShoppingCart();
            if (shoppingCart == null || !shoppingCart.ArticleIds.Any())
            {
                throw new WebShopException("At least 1 article should be added to the cart.");
            }

            var newCustomer = Mapper.Map<CustomerDto, Customer>(customer);
            var articles = shoppingCart.ArticleIds.Select (s => new Article{ArticleId = s}).ToList();
            var newOrder = new Order
            {
                Customer = newCustomer,
                Articles = articles
            };

            _unitOfWork.OrderRepository.Insert(newOrder);
            _unitOfWork.Save();

            _shoppingCartService.RemoveShoppingCart(shoppingCart.ShoppingCartId);
        }

        public decimal GetVatValue()
        {
            return Vat;
        }
    }
}
