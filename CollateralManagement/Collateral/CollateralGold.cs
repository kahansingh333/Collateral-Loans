using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.Collateral
{
    
    public class CollateralGold 
    {
        [Key]
        public int CollateralId { get; set; }

        public string GoldOwner { get; set; }

        public int YearInGoldBought { get; set; }

        public int GoldWeightinGrams { get; set; }

        public double GoldRateperGram { get; set; }

        public double GoldDepriciationRate { get; set; }

        public DateTime GoldPledgedDate { get; set; }

        [ForeignKey("CollateralId")]
        public virtual Collaterals Collaterals { get; set; }


        public virtual  double CurrentValue
        {
            get
            {
                return (GoldWeightinGrams * GoldRateperGram);
            }
        }


   
    }
}
