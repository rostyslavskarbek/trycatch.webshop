﻿using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using TryCatch.Dto;
using TryCatch.Services;
using TryCatch.WebShopApi.Models;
using TryCatch.WebShopApi.Models.Response;

namespace TryCatch.WebShopApi.Controllers
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
            var articles = Mapper.Map<IEnumerable<ArticleDto>, IEnumerable<Article>>(articlesDto);
            return RestResponse.Ok(articles);
        }
    }
}
