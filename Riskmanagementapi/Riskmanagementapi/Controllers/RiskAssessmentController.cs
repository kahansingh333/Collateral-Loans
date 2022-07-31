using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Riskmanagementapi.FlatFile;
using Riskmanagementapi.InputModels;
using Riskmanagementapi.Models;
using Riskmanagementapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riskmanagementapi.Controllers
{
    //[Authorize]
    public class RiskAssessmentController : ControllerBase
    {
       private readonly IRiskCalculator RiskCalculator;
        private IRiskAssessedList FlatFile;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public RiskAssessmentController(IRiskCalculator riskCalculator, IRiskAssessedList _FlatFile)
        {
            RiskCalculator = riskCalculator;
            FlatFile = _FlatFile;

        }
        // GET: RiskAssessment/5

        [HttpGet("RiskAssessment/{CollateralId}/{Update}")]
        public Task<Collateralrisk> GetCollateralRisk(int CollateralId, bool Update)
        {
            log.Debug("Entered the Controller to retrieve all the Collateral Details");

            if (!Update)
            {
                var Risk = FlatFile.GetRisksAssessed(CollateralId);
                if (Risk != null)
                {
                    
                    return Task.FromResult<Collateralrisk>(Risk);
                }
                else
                {
                    var RiskCalculated=  RiskCalculator.GetCollateralRisk(CollateralId);

                    FlatFile.AddRiskAssessed(RiskCalculated.Result);
                    
                    return RiskCalculated;

                }
            }

            else
            {
                var RiskCalculated = RiskCalculator.GetCollateralRisk(CollateralId);

                FlatFile.AddRiskAssessed(RiskCalculated.Result);

                return RiskCalculated;
            }

            
           
        }           
    }
}