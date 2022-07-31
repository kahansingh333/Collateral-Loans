using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementModule.OutputModels
{
    public class AllDetail
    {
        public int LoanId { get; set; }

        public int CustomerId { get; set; }

        public int CollateralId { get; set; }
        public string Name { get; set; }
        public long AccountNumber { get; set; }
        public double  EMI { get; set; }

        public int SanctionedLoan { get; set; }
        public bool ISCollateralIssued  { get; set; }

        public string CollateralDescription { get; set; }

    }
}
