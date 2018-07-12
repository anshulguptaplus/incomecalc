using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxPay.BusinessObjects.Dtos;
using TaxPay.BusinessObjects.Interfaces;

namespace TaxPay.Tests
{
    [TestClass]
    public class PaySlipServiceTests : IoCSupportedTest
    {
        [TestMethod]
        public void Test_GeneratePaySlip_With_TaxSlab1()
        {
            //Arrange
            var model = new PaySlipModel
            {
                FirstName = "David",
                LastName = "Miller",
                AnnualSalary = 18000,
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var paySlipService = Resolve<IPaySlipService>();
            var result = paySlipService.GetPaySlip(model);

            //Assert
            Assert.AreEqual(0, result.IncomeTax);
            Assert.AreEqual(1500, result.GrossIncome);
            Assert.AreEqual(1500, result.NetIncome);
            Assert.AreEqual(150, result.SuperAmount);
        }

        [TestMethod]
        public void Test_GeneratePaySlip_With_TaxSlab2()
        {
            //Arrange
            var model = new PaySlipModel
            {
                FirstName = "David",
                LastName = "Miller",
                AnnualSalary = 19000,
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var paySlipService = Resolve<IPaySlipService>();
            var result = paySlipService.GetPaySlip(model);

            //Assert
            Assert.AreEqual(13, result.IncomeTax);
            Assert.AreEqual(1583, result.GrossIncome);
            Assert.AreEqual(1570, result.NetIncome);
            Assert.AreEqual(158, result.SuperAmount);
        }

        [TestMethod]
        public void Test_GeneratePaySlip_With_TaxSlab3()
        {
            //Arrange
            var model = new PaySlipModel
            {
                FirstName = "David",
                LastName = "Miller",
                AnnualSalary = 38000,
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var paySlipService = Resolve<IPaySlipService>();
            var result = paySlipService.GetPaySlip(model);

            //Assert
            Assert.AreEqual(324, result.IncomeTax);
            Assert.AreEqual(3167, result.GrossIncome);
            Assert.AreEqual(2843, result.NetIncome);
            Assert.AreEqual(317, result.SuperAmount);
        }

        [TestMethod]
        public void Test_GeneratePaySlip_With_TaxSlab4()
        {
            //Arrange
            var model = new PaySlipModel
            {
                FirstName = "David",
                LastName = "Miller",
                AnnualSalary = 88000,
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var paySlipService = Resolve<IPaySlipService>();
            var result = paySlipService.GetPaySlip(model);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(7333, result.GrossIncome);
            Assert.AreEqual(5650, result.NetIncome);
            Assert.AreEqual(733, result.SuperAmount);
        }

        [TestMethod]
        public void Test_GeneratePaySlip_With_TaxSlab5()
        {
            //Arrange
            var model = new PaySlipModel
            {
                FirstName = "David",
                LastName = "Miller",
                AnnualSalary = 188000,
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var paySlipService = Resolve<IPaySlipService>();
            var result = paySlipService.GetPaySlip(model);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(15667, result.GrossIncome);
            Assert.AreEqual(10848, result.NetIncome);
            Assert.AreEqual(1567, result.SuperAmount);
        }

        [TestMethod]
        public void Test_GeneratePaySlip_With_Negative_Salary()
        {
            //Arrange
            var model = new PaySlipModel
            {
                FirstName = "David",
                LastName = "Miller",
                AnnualSalary = -188000,
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var paySlipService = Resolve<IPaySlipService>();
            var result = paySlipService.ValidateModel(model);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_GeneratePaySlip_With_Negative_SuperRate()
        {
            //Arrange
            var model = new PaySlipModel
            {
                FirstName = "David",
                LastName = "Miller",
                AnnualSalary = 188000,
                StartDate = "01 March – 31 March",
                SuperRate = -10
            };

            //Act
            var paySlipService = Resolve<IPaySlipService>();
            var result = paySlipService.ValidateModel(model);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_GeneratePaySlip_AnnualSalaryNotPassed()
        {
            //Arrange
            var model = new PaySlipModel
            {
                FirstName = "David",
                LastName = "Miller",
                StartDate = "01 March – 31 March",
                SuperRate = -10
            };

            //Act
            var paySlipService = Resolve<IPaySlipService>();
            var result = paySlipService.ValidateModel(model);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_GeneratePaySlip_SuperRateNotPassed()
        {
            //Arrange
            var model = new PaySlipModel
            {
                FirstName = "David",
                LastName = "Miller",
                AnnualSalary = 188000,
                StartDate = "01 March – 31 March"
            };

            //Act
            var paySlipService = Resolve<IPaySlipService>();
            var result = paySlipService.ValidateModel(model);

            //Assert
            Assert.IsFalse(result);
        }
    }
}