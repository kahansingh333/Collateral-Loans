using System;
using System.Collections.Generic;

namespace Riskmanagementapi.Models
{
    public class Collaterals
    {

        public int Id { get; set; }
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public string CollateralType { get;  set; }


    }
}
