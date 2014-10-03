using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using TryCatch.Dto;
using TryCatch.Services;
using TryCatch.WebShop.Models;
using TryCatch.WebShop.Models.Api;
using TryCatch.WebShop.Models.Api.Response;

namespace TryCatch.WebShop.Controllers.Api
{
    public class ArticleController : ApiController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public RestResponse Get()
        {
            var articlesDto = _articleService.GetArticles();
            var articles = Mapper.Map<IEnumerable<ArticleDto>, IEnumerable<ArticleApi>>(articlesDto);
            return RestResponse.Ok(articles);
        }

        [HttpGet]
        public RestResponse Get(string id)
        {
            var articleDto = _articleService.GetArticleById(id);
            var article = Mapper.Map<ArticleDto, ArticleDetailsApi>(articleDto);
            return RestResponse.Ok(article);
        }
    }
}
