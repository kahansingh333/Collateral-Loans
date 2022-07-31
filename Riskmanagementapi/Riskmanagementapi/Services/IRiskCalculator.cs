using Riskmanagementapi.InputModels;
using Riskmanagementapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riskmanagementapi.Services
{
    public interface IRiskCalculator
    {
        public Task<Collateralrisk> GetCollateralRisk(int CollateralId);

        public Collateralrisk CalcuclateRiskHouse(CollateralHouse House);


        public Collateralrisk CalcuclateRiskGold(CollateralGold Gold);

        public Collateralrisk CalcuclateRiskLand(CollateralLand Land);


    }
}
