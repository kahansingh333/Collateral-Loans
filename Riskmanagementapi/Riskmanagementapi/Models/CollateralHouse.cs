using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riskmanagementapi.Models
{
    public class CollateralHouse
    {


        public int CollateralId { get; set; }

        public string HouseOwner { get; set; }

        public string HouseAddress { get; set; }

        public int HouseArea { get; set; }

        public int YearinBuilt { get; set; }

        public long CurrentLandPricePerSqFt { get; set; }

        public long CurrentStructurePrice { get; set; }

        public int HouseDepriciationRate { get; set; }

        public DateTime PledgedDate { get; set; }



        public  double CurrentValue
        {
            get
            {
                return (HouseArea * CurrentLandPricePerSqFt) + CurrentStructurePrice;
            }
        }
    }
}
