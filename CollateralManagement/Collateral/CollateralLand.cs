using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.Collateral
{

    public class CollateralLand
    {
        [Key]
        public int CollateralId { get; set; }
        public string LandOwner { get; set; }
        public string LandAddress { get; set; }
        public int LandArea { get; set; }
        public long Pricepersquarefeet { get; set; }

        public int YearInLandBought { get; set; }
        public int LandDepriciationRate { get; set; }
        public DateTime PledgedDate { get; set; }

        [ForeignKey("CollateralId")]
        public virtual Collaterals Collaterals { get; set; }
        public virtual double CurrentValue
        {
            get
            {
                return Pricepersquarefeet * LandArea;
            }
        }

    }
}
