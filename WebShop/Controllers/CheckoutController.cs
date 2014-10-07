using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using TryCatch.Dto;
using TryCatch.Services;
using TryCatch.Services.ShoppingCart;
using TryCatch.WebShop.Models;
using TryCatch.WebShop.ViewModels;

namespace TryCatch.WebShop.Controllers
{
    public class CheckoutController : WebControllerBase
    {
        private readonly ICheckoutService _checkoutService;
        private readonly IShoppingCartService _shoppingCartService;

        public CheckoutController(ICheckoutService checkoutService, IShoppingCartService shoppingCartService)
        {
            _checkoutService = checkoutService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var vat = _checkoutService.GetVatValue();
            var articlesDto = _shoppingCartService.GetArticlesInCart();
            var articles = Mapper.Map<IEnumerable<ArticleDto>, IEnumerable<Article>>(articlesDto);
            var model = new CheckoutArticlesViewModel(articles, vat);
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new Customer());
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            var customerDto = Mapper.Map<CustomerDto>(customer);
             _checkoutService.CompleteCheckout(customerDto);
            return View("ThankYou");
        }
    }
}
