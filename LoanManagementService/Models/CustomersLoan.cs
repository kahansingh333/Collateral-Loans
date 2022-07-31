using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementModule.Models
{
    public class CustomersLoan
    {
        [Key]
        public int CustomerLoanId { get; set; }

       

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Loan")]
        public int LoanId { get; set; }

        public int SanctionedAmount { get; set; }

        public bool IsCollateraled { get; set; }

        public double EMI { get; set; }

        [Display(Name = "Collateral")]
        public int CollateralId { get; set; }

        [ForeignKey("CollateralId")]
        public virtual Collateral Collateral { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("LoanId")]
        public virtual Loan Loan { get; set; }

    }
}
