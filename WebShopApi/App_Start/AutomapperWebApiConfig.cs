using AutoMapper;
using TryCatch.Dto;
using TryCatch.WebShopApi.Models;

namespace TryCatch.WebShopApi.App_Start
{
    public class AutomapperWebApiConfig
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