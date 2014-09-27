using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using TryCatch.Repositories;
using TryCatch.Services.Article;

namespace TryCatch.WebShop
{
    public static class IocConfig
    {
        public static void RegisterDependencies()
        {
            ConfigureDependencyResolver();
        }

        private static void ConfigureDependencyResolver()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (MvcApplication).Assembly);

            builder.RegisterType<ArticleService>()
                .As<IArticleService>()
                .InstancePerHttpRequest();

            builder.RegisterType<ArticleRepository>()
                .As<IArticleRepository>()
                .InstancePerHttpRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}