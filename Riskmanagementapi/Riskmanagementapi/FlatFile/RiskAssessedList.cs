using Riskmanagementapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Riskmanagementapi.FlatFile
{
    public class RiskAssessedList :IRiskAssessedList
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<Collateralrisk> AssessedRisks = new List<Collateralrisk>();

        public void AddRiskAssessed(Collateralrisk Risk)
        {
            log.Debug("Updating Risk in FlatFile");
            var RiskPresentAlready = AssessedRisks.SingleOrDefault(x=>x.CollateralId==Risk.CollateralId);
          


                //AssessedRisks.RemoveAt(Index);

             AssessedRisks.Remove(RiskPresentAlready);

            AssessedRisks.Add(Risk);

            

           
        }

        public Collateralrisk GetRisksAssessed(int CollateralId)
        {
            log.Debug("Returing Risk From the Flat File");
            return AssessedRisks.SingleOrDefault(x=>x.CollateralId==CollateralId);
        }
    }
}
