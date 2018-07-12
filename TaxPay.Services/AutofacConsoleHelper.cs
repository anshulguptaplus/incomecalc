using Autofac;
using TaxPay.Services.Infrastructure;

namespace TaxPay.Services
{
    public class AutofacConsoleHelper
    {
        private readonly IContainer _container;

        public AutofacConsoleHelper()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ServiceModule());

            // BUILD THE CONTAINER
            _container = builder.Build();

            IocManager.Instance.IocContainer = _container;
            IocManager.Instance.PlatformExecutionType = PlatformExecutionType.Console;
        }

        public TEntity Resolve<TEntity>()
        {
            return _container.Resolve<TEntity>();
        }

        public void ShutdownIoC()
        {
            _container.Dispose();
        }
    }
}