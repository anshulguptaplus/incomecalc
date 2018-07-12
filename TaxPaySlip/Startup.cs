using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using TaxPay;

[assembly: OwinStartup(typeof(Startup))]

namespace TaxPay
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureDi();
        }

        private static void ConfigureDi()
        {
            var builder = new ContainerBuilder();

            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterModule(new ServiceModule());

            // BUILD THE CONTAINER
            var container = builder.Build();

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            Manager.Instance.IocContainer = container;
        }
    }
}