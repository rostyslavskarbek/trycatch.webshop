using System;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using TryCatch.Repositories;
using TryCatch.Repositories.UnitOfWork;
using TryCatch.Services;
using TryCatch.Services.ShoppingCart;

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
            builder.RegisterApiControllers(typeof (MvcApplication).Assembly);

            builder.RegisterType<ArticleService>()
                .As<IArticleService>()
                .InstancePerHttpRequest();
            builder.RegisterType<ShoppingCartService>()
                .As<IShoppingCartService>()
                .InstancePerHttpRequest();
            builder.RegisterType<CheckoutService>()
                .As<ICheckoutService>()
                .InstancePerHttpRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerDependency();

            builder.RegisterType<ArticleRepository>()
                .As<IArticleRepository>()
                .InstancePerHttpRequest();
            

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}