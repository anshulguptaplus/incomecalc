using System;
using TaxPay.BusinessObjects.Calculation;
using TaxPay.BusinessObjects.Dtos;
using TaxPay.BusinessObjects.Interfaces;
using TaxPay.BusinessObjects.ResultModel;
using TaxPay.Services.Infrastructure;

namespace TaxPay.Services
{
    public class PaySlipService : IPaySlipService, IPaySlipDemoService
    {
        public PaySlipResultModel GetPaySlip(PaySlipModel model)
        {
            #region Negative values validations

            if (model.AnnualSalary <= 0) throw new Exception("Salary should be positive value");

            if (model.SuperRate < 0) throw new Exception("Super Rate should be positive value");

            #endregion

            var annualSalary = model.AnnualSalary;
            var grossIncome = annualSalary.CalculateGrossIncome();
            var incomeTax = annualSalary.GetTaxSlabAmount();
            var netIncome = (grossIncome - incomeTax).RoundOffDoller();
            var superAmount = (grossIncome * model.SuperRate / 100).RoundOffDoller();

            var viewModel = new PaySlipResultModel
            {
                Name = $"{model.FirstName} {model.LastName}",
                NetIncome = netIncome,
                GrossIncome = grossIncome,
                IncomeTax = incomeTax,
                PayPeriod = model.StartDate,
                SuperAmount = superAmount
            };

            return viewModel;
        }

        public bool ValidateModel(PaySlipModel paySlipModel)
        {
            if (paySlipModel.AnnualSalary <= 0 || paySlipModel.SuperRate <= 0)
                return false;

            return true;
        }
    }
}