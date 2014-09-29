using System.Web.Mvc;
using AutoMapper;
using TryCatch.Dto;
using TryCatch.Services.Article;
using TryCatch.Services.ShoppingCart;
using TryCatch.WebShop.Models;
using TryCatch.WebShop.ViewModels;

namespace TryCatch.WebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IArticleService _articleService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IArticleService articleService)
        {
            _shoppingCartService = shoppingCartService;
            _articleService = articleService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var shoppingCartDto = _shoppingCartService.GetShoppingCart();
            var shoppingCartModel = new ShoppingCart();
            shoppingCartModel.CartId = shoppingCartDto.ShoppingCartId;
            foreach (var articleId in shoppingCartDto.ArticleIds)
            {
                var articleDto = _articleService.GetArticleById(articleId);
                var articleModel = Mapper.Map<ArticleDto, Article>(articleDto);
                shoppingCartModel.Items.Add(articleModel);
            }

            return View(shoppingCartModel);
        }

        [HttpPost]
        public ActionResult AddToCart(string id)
        {
            var isAdded = _shoppingCartService.AddToShoppingCart(id);
            var result = new ShoppingCartArticleActionViewModel
            {
                IsSuccessful = isAdded,
                ErrorMessage = isAdded ? string.Empty : "Could not add article to the cart.",
                ArticleId = id,
                ItemsInCart = _shoppingCartService.GetItemsQuantityInCart()
            };

            return Json(result);
        }

        [HttpPost]
        public ActionResult RemoveFromCart(string id)
        {
            var isRemoved = _shoppingCartService.RemoveFromShoppingCart(id);
            var result = new ShoppingCartArticleActionViewModel
            {
                IsSuccessful = isRemoved,
                ErrorMessage = isRemoved ? string.Empty : "Could not remove article from the cart.",
                ArticleId = id,
                ItemsInCart = _shoppingCartService.GetItemsQuantityInCart()
                
            };

            return Json(result);
        }

        [HttpGet]
        public JsonResult ItemsInCart()
        {
            var cartItems = _shoppingCartService.GetItemsQuantityInCart();
            return Json(cartItems, JsonRequestBehavior.AllowGet);
        }
    }
}
