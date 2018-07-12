using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPay.Services;

namespace TaxPay.Tests
{
    public class IoCSupportedTest
    {
        private readonly AutofacConsoleHelper _helper;

        public IoCSupportedTest()
        {
            _helper = new AutofacConsoleHelper();
        }

        protected TEntity Resolve<TEntity>()
        {
            return _helper.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            _helper.ShutdownIoC();
        }
    }
}
