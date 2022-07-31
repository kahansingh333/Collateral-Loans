using CollateralManagement.Collateral;
using CollateralManagement.Models;
using CollateralManagement.OutputModels;
using CollateralManagement.SaveCollateralHelper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CollateralManagement.Repository
{
    public class CollateralClassification : IClassification
    {
        private readonly IDatabaseSaver helper;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CollateralClassification(IDatabaseSaver _helper)
        {
            helper = _helper;
        }
       
        /*
            This method classifies the received json element to
            the appropriate collateral type
         */
        public async Task<Result> ClassifyPostedCollateralType(JsonElement element)
        {
            log.Debug("Classifying the Collateral Data Recieved According to Type");
            var details = JObject.Parse(element.ToString());
            //##### After classification mapper can be called and then savehelper from there

            if (details["CollateralType"].ToString().Equals("Gold"))
            {
               return  await helper.SaveGoldCollateralAsync(details);
            }
            
            else if (details["CollateralType"].ToString().Equals("House"))
            {
                return await  helper.SaveHouseCollateralAsync(details);
            }

            else if (details["CollateralType"].ToString().Equals("Land"))
            {
                return await helper.SaveLandCollateralAsync(details);
            }
            else
            {
                return new Result { Saved = false, type = "The collateral type received from jsonElement was either invalid, undefined or unimplemented" };
            }
            
        }

       
    }
}
