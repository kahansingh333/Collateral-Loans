using CollateralManagement.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

//####### Could be named classifier something add can have a Json element model mapper function

namespace CollateralManagement.Repository
{
    public interface IClassification
    {
        public Task<Result> ClassifyPostedCollateralType(JsonElement element );
    }
}
