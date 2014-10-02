using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TryCatch.WebShop.Models;

namespace TryCatch.WebShop.ViewModels
{
    public class CheckoutArticlesViewModel
    {
        private readonly decimal _vat;
        public CheckoutArticlesViewModel(IEnumerable<Article> articles, decimal vat)
        {
            Articles = articles;
            _vat = vat;
        }

        public IEnumerable<Article> Articles { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal TotalPriceIncludingVat
        {
            get { return Articles.Sum(a => a.Price) * (1 + _vat); }
        }

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal TotalVat
        {
            get { return TotalPriceIncludingVat - TotalPriceExcludingVat; }
        }

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal TotalPriceExcludingVat
        {
            get { return Articles.Sum(a => a.Price); }
        }
    }
}