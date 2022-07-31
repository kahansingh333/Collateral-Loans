using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementModule.Models
{
    public class Collateral
	{
		public int Id { get; set; }

        public string Description { get; set; }

        public Collateral()
		{ }
	}
}
