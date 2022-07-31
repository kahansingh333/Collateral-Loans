using Newtonsoft.Json.Linq;
using Riskmanagementapi.InputModels;
using Riskmanagementapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Riskmanagementapi.FlatFile;

namespace Riskmanagementapi.Services
{
    public class RiskCalculator : IRiskCalculator
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        //Classifies collateral types from http request and calls the above methods
        public async Task<Collateralrisk> GetCollateralRisk(int CollateralId)
        {
            log.Debug("Sending Requiest to Retrieve the Collateral Details");
            using (var client = new HttpClient())
            {
                string RequestString = $"https://localhost:5002/GetCollateral/{CollateralId}";
                //var content = new StringContent(collateral.ToString(), Encoding.UTF8, "application/json");
                var response = client.GetAsync(RequestString).Result;

                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    //var jsonobj = JObject.Parse(jsonString);

                    RiskOutputModel output = JsonSerializer.Deserialize<RiskOutputModel>(jsonString);

                    if (output.Type == "Land")
                    {
                        var Land = JsonSerializer.Deserialize<CollateralLand>(output.Collateral);


                        return CalcuclateRiskLand(Land);

                    }
                    else if (output.Type == "Gold")
                    {
                        var Gold = JsonSerializer.Deserialize<CollateralGold>(output.Collateral);
                        return CalcuclateRiskGold(Gold);

                    }
                    else if (output.Type == "House")
                    {
                        var House = JsonSerializer.Deserialize<CollateralHouse>(output.Collateral);
                        return CalcuclateRiskHouse(House);

                    }

                }

                return null;

            }
        }
        //CollateralRiskGold calculates the risk made by land as a collateral
        public Collateralrisk CalcuclateRiskGold(CollateralGold collateralGold)
        {
            log.Debug("Calculating the Risk of Gold Collateral");

            Collateralrisk collateralRisk = new Collateralrisk();

            var YearInGoldBought = collateralGold.YearInGoldBought;
    
            int Difference = DateTime.Now.Year - YearInGoldBought;
            double marketValue = collateralGold.CurrentValue -( (collateralGold.GoldDepriciationRate * collateralGold.CurrentValue * Difference) / 100);

            if (collateralGold.CurrentValue > marketValue)
            {
                collateralRisk.CollateralId = collateralGold.CollateralId;
                collateralRisk.RiskPercentage = (long)((Math.Abs(collateralGold.CurrentValue - marketValue) * 100) / collateralGold.CurrentValue);
                collateralRisk.DateAssessed = DateTime.Now;
            }
            else
            {
                collateralRisk.CollateralId = collateralGold.CollateralId;
                collateralRisk.DateAssessed = DateTime.Now;
                collateralRisk.RiskPercentage = 0;
            }
            return collateralRisk;
        }

        //CollateralRiskHouse calculates the risk made by House as a collateral
        public Collateralrisk CalcuclateRiskHouse(CollateralHouse collateralHouse)
        {
            log.Debug("Calculating the Risk of House Collateral");
            Collateralrisk collateralRisk = new Collateralrisk();

            var YearInHouseBuilt = collateralHouse.YearinBuilt;


            int Difference = DateTime.Now.Year - YearInHouseBuilt;
           
            if (collateralHouse != null)
            {

                double marketValue = collateralHouse.CurrentValue - (collateralHouse.CurrentValue * collateralHouse.HouseDepriciationRate * Difference) / 100;

                if (collateralHouse.CurrentValue > marketValue)
                {
                    collateralRisk.CollateralId = collateralHouse.CollateralId;
                    collateralRisk.RiskPercentage = (long)((Math.Abs(collateralHouse.CurrentValue - marketValue) * 100) / collateralHouse.CurrentValue);
                    collateralRisk.DateAssessed = DateTime.Now;
                }
                else
                {
                    collateralRisk.CollateralId = collateralHouse.CollateralId;
                    collateralRisk.DateAssessed = DateTime.Now;
                    collateralRisk.RiskPercentage = 0;
                }
            }
            return collateralRisk;
        }
       

         
        //CollateralRiskLand calculates the risk made by land as a collateral
        public Collateralrisk CalcuclateRiskLand(CollateralLand collateralLand)
        {
            
            log.Debug("Calculating the Risk of Land Collateral");

            Collateralrisk collateralRisk = new Collateralrisk();
            var YearInLandBought = collateralLand.YearInLandBought;


            int Difference = DateTime.Now.Year - YearInLandBought;

            long marketValue = (long)(collateralLand.CurrentValue - (collateralLand.LandDepriciationRate * collateralLand.CurrentValue * Difference) / 100);

            if (collateralLand.CurrentValue > marketValue)
            {
                collateralRisk.CollateralId = collateralLand.CollateralId;
                collateralRisk.RiskPercentage = (long)((Math.Abs(collateralLand.CurrentValue - marketValue) * 100) / collateralLand.CurrentValue);
                collateralRisk.DateAssessed = DateTime.Now;
            }
            else
            {
                collateralRisk.CollateralId = collateralLand.CollateralId;
                collateralRisk.DateAssessed = DateTime.Now;
                collateralRisk.RiskPercentage = 0;
            }
            return collateralRisk;

        }

      
        

    
    }
}
