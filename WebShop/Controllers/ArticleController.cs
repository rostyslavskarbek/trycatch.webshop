using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using TryCatch.Dto;
using TryCatch.Services.Article;
using TryCatch.WebShop.Models;

namespace TryCatch.WebShop.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public ActionResult Index()
        {
            var articlesDto = _articleService.GetArticles();
            var articles = Mapper.Map<IEnumerable<ArticleDto>, IEnumerable<Article>>(articlesDto);
            return View(articles);
        }

        public ActionResult Details(string id)
        {
            var articleDto = _articleService.GetArticleById(id);
            var articleDetails = Mapper.Map<ArticleDto, Article>(articleDto);
            return View(articleDetails);
        }
    }
}