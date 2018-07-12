using System;
using Autofac;

namespace TaxPay
{
    public class Manager
    {
        static Manager()
        {
            Instance = new Manager();
        }

        private Manager()
        {
        }

        /// <summary>
        ///     The Singleton instance.
        /// </summary>
        public static Manager Instance { get; }

        /// <summary>
        ///     Reference to the Autofac Container.
        /// </summary>
        public IContainer IocContainer { get; set; }

        /// <inheritdoc />
        public void Dispose()
        {
            IocContainer.Dispose();
        }

        public bool IsRegistered(Type type)
        {
            using (var scope = IocContainer.BeginLifetimeScope())
            {
                return scope.IsRegistered(type);
            }
        }

        public bool IsRegistered<T>()
        {
            using (var scope = IocContainer.BeginLifetimeScope())
            {
                return scope.IsRegistered(typeof(T));
            }
        }
    }
}