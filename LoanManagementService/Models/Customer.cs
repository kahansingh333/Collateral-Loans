using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementModule.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int CustomerAge { get; set; }

        public long CustomerPhoneNumber { get; set; }
        public long CustomerAccountNumber { get; set; }
        public virtual CustomersLoan CustomerLoan { get; set; }

    }
}
