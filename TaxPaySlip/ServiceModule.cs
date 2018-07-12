using System;
using System.Linq;
using Autofac;
using TaxPay.Services.Infrastructure;

namespace TaxPay
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var serviceAssembly = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .FirstOrDefault(a => !a.IsDynamic && a.GetName()
                                         .Name
                                         .Contains("TaxPay.Services"));

            builder.RegisterAssemblyTypes(serviceAssembly)
                .Where(t => t.GetInterfaces().Any(i => i == typeof(IPaySlipDemoService)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired();
        }
    }
}