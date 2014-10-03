using AutoMapper;
using TryCatch.Dto;
using TryCatch.WebShop.Models;
using TryCatch.WebShop.Models.Api;

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
            Mapper.CreateMap<ArticleDto, ArticleApi>();
            Mapper.CreateMap<ArticleDto, ArticleDetailsApi>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Customer, CustomerDto>();
        }
    }
}