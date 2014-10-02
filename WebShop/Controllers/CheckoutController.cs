using System.Web.Mvc;
using AutoMapper;
using TryCatch.Dto;
using TryCatch.Services;
using TryCatch.WebShop.Models;

namespace TryCatch.WebShop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Customer{Address = "Legionow", EmailAddress = "rere@asds.com", City = "Wroclaw", FirstName = "Dutka", HouseNumber = "34", LastName = "Rootrr", Title = "Mrs", ZipCode = "4564"});
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            var customerDto = Mapper.Map<CustomerDto>(customer);
             _checkoutService.CompleteCheckout(customerDto);
            return View("ThankYou");
        }
    }
}
