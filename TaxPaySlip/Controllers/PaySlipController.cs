using System.Web.Http;
using TaxPay.BusinessObjects.Dtos;
using TaxPay.BusinessObjects.Interfaces;

namespace TaxPay.Controllers
{
    [RoutePrefix("api/payslip")]
    public class PaySlipController : ApiController
    {
        private readonly IPaySlipService _paySlipService;

        public PaySlipController(IPaySlipService paySlipService)
        {
            _paySlipService = paySlipService;
        }

        [HttpPost]
        [Route("GeneratePaySlip")]
        public IHttpActionResult GeneratePaySlip(PaySlipModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            if (!_paySlipService.ValidateModel(model))
                return BadRequest();

            var viewModel = _paySlipService.GetPaySlip(model);
            return Ok(viewModel);
        }
    }
}