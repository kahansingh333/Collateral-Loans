using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.Collateral
{
    public class Collaterals
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public string CollateralType { get;  set; }

        

    }
}
