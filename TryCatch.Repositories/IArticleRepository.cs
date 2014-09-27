using System;
using System.Linq;
using TryCatch.Dto;

namespace TryCatch.Repositories
{
    public interface IArticleRepository : IDisposable
    {
        IQueryable<ArticleDto> GetArticles();
        ArticleDto GetArticleById(string id);
    }
}
