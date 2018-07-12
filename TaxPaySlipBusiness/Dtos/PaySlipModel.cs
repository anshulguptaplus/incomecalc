using System.ComponentModel.DataAnnotations;

namespace TaxPay.BusinessObjects.Dtos
{
    public class PaySlipModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public decimal AnnualSalary { get; set; }
        [Required]
        public decimal SuperRate { get; set; }
        [Required]
        public string StartDate { get; set; }
    }
}
