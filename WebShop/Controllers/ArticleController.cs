using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using TryCatch.Dto;
using TryCatch.Services;
using TryCatch.WebShop.Models;

namespace TryCatch.WebShop.Controllers
{
    public class ArticleController : WebControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var articlesDto = _articleService.GetArticles();
            var articles = Mapper.Map<IEnumerable<ArticleDto>, IEnumerable<Article>>(articlesDto);
            var model = new PagedList<Article>(articles, page, pageSize);

            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("ListOfArticles", model)
                : View(model);
        }

        public ActionResult Details(string id)
        {
            var articleDto = _articleService.GetArticleById(id);
            var articleDetails = Mapper.Map<ArticleDto, Article>(articleDto);
            return View(articleDetails);
        }

        public ActionResult ArticlesOverview()
        {
            return View();
        }
    }
}