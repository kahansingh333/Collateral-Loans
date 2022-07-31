using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementModule.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        [Required]
        public string LoanName { get; set; }
        public int LoanMaxAmount { get; set; }

        public double Interest { get; set; }

        public byte LoanTenureInYears { get; set; }
        public string TypeOfCollateralAccepted { get; set; }

        
    }
}
