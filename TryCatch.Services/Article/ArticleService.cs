using System.Collections.Generic;
using System.Linq;
using TryCatch.Dto;
using TryCatch.Repositories;

namespace TryCatch.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleDto> GetArticles()
        {
            return _articleRepository.GetArticles().ToList();
        }

        public ArticleDto GetArticleById(string id)
        {
            return _articleRepository.GetArticleById(id);
        }
    }
}
