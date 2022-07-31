using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanManagementModule.Services
{
    //Service to Send the Collateral Data to CollateralManagement Service
    public class CollateralService : ICollateralService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Sending the Collateral Data to Collateral MAnagement APi
        public async Task<string> SaveCollateralAsync(JsonElement collateral)
        {
            log.Debug("Trying to send the data to Collateral Management Service");
            using (var client = new HttpClient())
            {
                //https://localhost:5002
                var content = new StringContent(collateral.ToString(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:5002/SaveCollateral", content);
                if (response != null)
                {
                    log.Debug("Response Recived from the Collateral Management is Not Null");

                    var jsonString = await response.Content.ReadAsStringAsync();
                    log.Debug("Response Recived from the Collateral Management is " + jsonString);

                    return (jsonString);
                }

                return null;

            }
        }
    }
}
