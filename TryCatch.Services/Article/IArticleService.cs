using System.Collections.Generic;
using TryCatch.Dto;

namespace TryCatch.Services
{
    public interface IArticleService
    {
        List<ArticleDto> GetArticles();
        ArticleDto GetArticleById(string id);
    }
}
