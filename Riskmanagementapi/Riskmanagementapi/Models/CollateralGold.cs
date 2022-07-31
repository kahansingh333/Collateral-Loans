using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riskmanagementapi.Models
{
    public class CollateralGold
    {
       
        public int CollateralId { get; set; }

        public string GoldOwner { get; set; }

        public int YearInGoldBought { get; set; }

        public int GoldWeightinGrams { get; set; }

        public double GoldRateperGram { get; set; }

        public double GoldDepriciationRate { get; set; }

        public DateTime GoldPledgedDate { get; set; }

        public  double CurrentValue
        {
            get
            {
                return (GoldWeightinGrams * GoldRateperGram);
            }
        }


    }
}
