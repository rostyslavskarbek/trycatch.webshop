using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using TryCatch.Repositories;
using TryCatch.Repositories.UnitOfWork;
using TryCatch.Services;

namespace TryCatch.WebShopApi.App_Start
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            ConfigureDependencyResolver();
        }

        private static void ConfigureDependencyResolver()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterType<ArticleService>()
                .As<IArticleService>()
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerDependency();

            builder.RegisterType<ArticleRepository>()
                .As<IArticleRepository>()
                .InstancePerRequest();


            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}