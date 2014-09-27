using AutoMapper;
using TryCatch.Dto;
using TryCatch.WebShop.Models;

namespace TryCatch.WebShop
{
    public static class AutoMapperWebConfig
    {
        public static void Configure()
        {
            ConfigureWebModels();
        }

        private static void ConfigureWebModels()
        {
            Mapper.CreateMap<ArticleDto, Article>();
        }
    }
}