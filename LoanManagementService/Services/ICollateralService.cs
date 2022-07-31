using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanManagementModule.Services
{
    public interface ICollateralService
    {

        public  Task<string> SaveCollateralAsync(JsonElement collateral );
    }
}
