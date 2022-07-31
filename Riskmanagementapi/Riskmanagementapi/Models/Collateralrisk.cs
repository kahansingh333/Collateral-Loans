using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Riskmanagementapi.Models
{
    public class Collateralrisk
    {
  
        public int CollateralId { get; set; }

        public long RiskPercentage { get; set; }
        public DateTime DateAssessed { get; set; }
    }
}
