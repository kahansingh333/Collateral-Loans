using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.Collateral
{

    public class CollateralHouse
    {
        [Key]
        public int CollateralId { get; set; }


        public string HouseOwner { get; set; }

        public string HouseAddress { get; set; }

        public int HouseArea { get; set; }

        public int YearinBuilt { get; set; }

        public long CurrentLandPricePerSqFt { get; set; }

        public long CurrentStructurePrice { get; set; }

        public int HouseDepriciationRate { get; set; }

        public DateTime PledgedDate { get; set; }

        [ForeignKey("CollateralId")]
        public virtual Collaterals Collaterals { get; set; }


        public virtual  double CurrentValue
        {
            get
            {
                return (HouseArea * CurrentLandPricePerSqFt) + CurrentStructurePrice;
            }
        }

     

    }
}
