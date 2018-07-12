using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPay.BusinessObjects.Dtos;
using TaxPay.BusinessObjects.ResultModel;

namespace TaxPay.BusinessObjects.Interfaces
{
    public interface IPaySlipService
    {
        PaySlipResultModel GetPaySlip(PaySlipModel model);
        bool ValidateModel(PaySlipModel paySlipModel);
    }
}
