using CollateralManagement.Collateral;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.OutputModels
{
    public class Result
    {
        public bool Saved { get; set; }

        public string type { get; set; }
    }
}
