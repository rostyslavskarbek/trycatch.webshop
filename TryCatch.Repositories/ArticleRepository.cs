using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AutoMapper;
using TryCatch.Dto;
using TryCatch.XmlDal;
using TryCatch.XmlDal.Entities;

namespace TryCatch.Repositories
{
    public class ArticleRepository : EntityXmlRepository<ArticleXml>, IArticleRepository
    {
        public ArticleRepository() : base("Article")
        {
            Mapper.CreateMap<ArticleXml, ArticleDto>();
            Mapper.CreateMap<ArticleDto, ArticleXml>();
        }

        public IQueryable<ArticleDto> GetArticles()
        {
            var articlesXml = GetAll();
            var articlesDto = Mapper.Map<IEnumerable<ArticleXml>, IEnumerable<ArticleDto>>(articlesXml);
            return articlesDto.AsQueryable();
        }

        public ArticleDto GetArticleById(string id)
        {
            var articleXml = GetById(id);
            return Mapper.Map<ArticleXml, ArticleDto>(articleXml);
        }

        public override ArticleXml GetById(string id)
        {
            return ParentElement.Elements(ElementName)
                   .Where(e =>
                   {
                       var xElement = e.Element("ArticleId");
                       return xElement != null && xElement.Value == id;
                   })
                   .Select(Selector).FirstOrDefault();
        }

        public void Dispose()
        {
            
        }

        protected override XElement GetParentElement()
        {
            return DocumentProvider.GetDocument().Elements().First();
        }

        protected override Func<XElement, ArticleXml> Selector
        {
            get
            {
                return x => new ArticleXml
                {
                    ArticleId = x.Element("ArticleId").Value,
                    Name = x.Element("Name").Value,
                    Price = x.Element("Price").Value,
                    Description = x.Element("Description").Value,
                    Author = x.Element("Author").Value,
                    Publisher = x.Element("Publisher").Value
                };
            }
        }
    }
}
