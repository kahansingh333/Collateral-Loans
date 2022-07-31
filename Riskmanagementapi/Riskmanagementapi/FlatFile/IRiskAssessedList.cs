using Riskmanagementapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riskmanagementapi.FlatFile
{
    public interface IRiskAssessedList
    {
        public Collateralrisk GetRisksAssessed(int CollateralId);

        public void AddRiskAssessed(Collateralrisk Risk);

    }
}
