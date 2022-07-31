using CollateralManagement.Collateral;
using CollateralManagement.OutputModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.SaveCollateralHelper
{
    public interface IDatabaseSaver
    {
        public Task<Result> SaveGoldCollateralAsync(JObject details);
        public Task<Result> SaveHouseCollateralAsync(JObject details);
        public Task<Result> SaveLandCollateralAsync(JObject details);
        public RiskOutputModel GetCollateralDetailsFromSpecificTable(int loanid); 

    }
}
