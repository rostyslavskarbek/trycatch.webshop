using System.Collections.Generic;
using TryCatch.Dto;

namespace TryCatch.Services.Article
{
    public interface IArticleService
    {
        List<ArticleDto> GetArticles();
        ArticleDto GetArticleById(string id);
    }
}
