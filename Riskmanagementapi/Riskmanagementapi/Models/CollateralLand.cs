using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riskmanagementapi.Models
{
    public class CollateralLand
    {

        public int CollateralId { get; set; }
        public string LandOwner { get; set; }

        public string LandAddress { get; set; }

        public int LandArea { get; set; }
        public long Pricepersquarefeet { get; set; }

        public int YearInLandBought { get; set; }
        public int LandDepriciationRate { get; set; }

        public DateTime PledgedDate { get; set; }


        public  double CurrentValue
        {
            get
            {
                return Pricepersquarefeet * LandArea;
            }
        }

    }
}
