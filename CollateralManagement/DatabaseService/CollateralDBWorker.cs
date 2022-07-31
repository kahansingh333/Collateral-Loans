using CollateralManagement.Collateral;
using CollateralManagement.Models;
using CollateralManagement.OutputModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

/*
 Functions: 
        -Adding to Dbcontext 
        -Saving to Database
 */

//###### Can be split in mapping in one and adding to context and saving to db in one


namespace CollateralManagement.SaveCollateralHelper
{
    public class CollateralDBWorker:IDatabaseSaver
    {
        private CollateralDbContext ctx;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CollateralDBWorker(CollateralDbContext _ctx)
        {
            ctx = _ctx;
        
        }

        public RiskOutputModel GetCollateralDetailsFromSpecificTable(int collateralid)
        {
            log.Debug("To Get the Collateral Details From Specific Table");

            var objoftable = ctx.CollateralLoans.FirstOrDefault(loan => loan.Id == collateralid);
            var reqcollateralid = objoftable.Id;
            var RequestedCollateralType = objoftable.CollateralType;

            RiskOutputModel OutputModel = new RiskOutputModel();

            OutputModel.Type = RequestedCollateralType;
            log.Debug("Type of Collateral is" + RequestedCollateralType);

            if (RequestedCollateralType == "Land")
            {
                
                //search land table
                var requested_collateral1 = ctx.CollateralLand.FirstOrDefault(landcollateral => landcollateral.CollateralId == collateralid);

                OutputModel.Collateral = System.Text.Json.JsonSerializer.Serialize(requested_collateral1);

                return OutputModel;

                   
                //(JObject)JToken.FromObject(requested_collateral); ;
            }
            else if(RequestedCollateralType == "House")
            {
                //search house table
                var requested_collateral2 = ctx.CollateralHouse.FirstOrDefault(landcollateral => landcollateral.CollateralId == collateralid);

                OutputModel.Collateral = System.Text.Json.JsonSerializer.Serialize(requested_collateral2);
            
                return OutputModel;

            }
            else if(RequestedCollateralType == "Gold")
            {
                //search gold table
                var requested_collateral3 = ctx.CollateralGold.FirstOrDefault(landcollateral => landcollateral.CollateralId == collateralid);

                OutputModel.Collateral = System.Text.Json.JsonSerializer.Serialize(requested_collateral3);

                return OutputModel;

            }
            else
            {
                return OutputModel;
            }

        }


        //Saves to gold collaterals table 
        public async Task<Result> SaveGoldCollateralAsync(JObject details)
        {
            log.Debug("Parse the Data to Save Gold Collateral");
            Collaterals collateral = new Collaterals();
            CollateralGold gold = new CollateralGold();
          
            var CollateralId = Int32.Parse(details["CollateralId"].ToString());
            collateral.Id = CollateralId;
          
            collateral.LoanId = Int32.Parse(details["LoanId"].ToString());
         
            collateral.CustomerId = Int32.Parse(details["CustomerId"].ToString());

            collateral.CollateralType = "Gold";

            gold.CollateralId = CollateralId;
         
            gold.GoldOwner = details["GoldOwner"].ToString();

        
            gold.GoldWeightinGrams = Int32.Parse(details["Weight"].ToString());

          
            gold.GoldRateperGram = Double.Parse(details["GoldValue"].ToString());

          
            gold.YearInGoldBought = Int32.Parse(details["YearInGoldBought"].ToString());

            gold.GoldDepriciationRate = Double.Parse(details["GoldDepriciationRate"].ToString());

          
            gold.GoldPledgedDate = DateTime.Parse(details["GoldPledgedDate"].ToString());

            try
            {
                await ctx.CollateralLoans.AddAsync(collateral);
                await ctx.CollateralGold.AddAsync(gold);
                await  ctx.SaveChangesAsync();
                log.Debug("Successfully Saved Gold Collateral");
                return new Result { Saved = true, type = "Gold" };
            }

            catch (Exception e)
            {
                log.Debug("Exception Occured While Saving Gold Collateral");

                return new Result { Saved = false, type = e.Message };
            }

        }

        //Saves to house collaterals table
        public async Task<Result> SaveHouseCollateralAsync(JObject details)
        {
            log.Debug("Parse the Data to Save House Collateral");

            Collaterals Collateral = new Collaterals();
            CollateralHouse House = new CollateralHouse();

            var CollateralId = Int32.Parse(details["CollateralId"].ToString());
            Collateral.Id = CollateralId;
            Collateral.LoanId = Int32.Parse(details["LoanId"].ToString());

            Collateral.CustomerId = Int32.Parse(details["CustomerId"].ToString());

            Collateral.CollateralType = "House";

            House.CollateralId = CollateralId;

            House.HouseOwner = details["HouseOwner"].ToString();

            House.HouseAddress = (details["HouseAddress"].ToString());

            House.YearinBuilt = Int32.Parse(details["HouseYear"].ToString());

            House.HouseArea = Int32.Parse(details["HouseArea"].ToString());

            House.CurrentLandPricePerSqFt = long.Parse(details["HouseCurrentvalue"].ToString());

            House.PledgedDate = DateTime.Parse(details["HousePledgedDate"].ToString());

            House.HouseDepriciationRate= Int32.Parse(details["HouseDeprecationRate"].ToString());

            House.CurrentStructurePrice = long.Parse(details["HouseCurrentStructureValue"].ToString());

            await ctx.CollateralLoans.AddAsync(Collateral);

            try
            {
                    ctx.CollateralHouse.Add(House);
                    await ctx.SaveChangesAsync();
                    log.Debug("Successfully Saved House Collateral");

                return new Result { Saved = true, type = "House" };
            }
                
            catch (Exception e)
            {
                log.Debug("Exception Occured While Saving House Collateral");

                return new Result { Saved = false, type = e.Message };
            }
      
        }

        //Saves to land collaterals table
        public async Task<Result> SaveLandCollateralAsync(JObject details)
        {
            log.Debug("Parse the Data to Save Land Collateral");

            Collaterals collateral = new Collaterals();

            CollateralLand land = new CollateralLand();

            var collateralid = Int32.Parse(details["CollateralId"].ToString());
            collateral.Id = collateralid;

            collateral.LoanId = Int32.Parse(details["LoanId"].ToString());

            collateral.CustomerId = Int32.Parse(details["CustomerId"].ToString());

            collateral.CollateralType = "Land";

            land.CollateralId = collateralid;

            land.LandOwner = details["LandOwner"].ToString();

            land.LandAddress = details["LandAddress"].ToString();

            land.LandArea = Int32.Parse(details["LandArea"].ToString());

            land.YearInLandBought= Int32.Parse(details["PropertyYear"].ToString());

            land.Pricepersquarefeet= Int32.Parse(details["LandCurrentvalue"].ToString()); 
;

            land.PledgedDate = DateTime.Parse(details["LandPledgedDate"].ToString());

            land.LandDepriciationRate = Int32.Parse(details["LandDepriciationRate"].ToString());

            try
            {
                await ctx.CollateralLoans.AddAsync(collateral);
                await ctx.CollateralLand.AddAsync(land);
                await ctx.SaveChangesAsync();
                log.Debug("Successfully Saved Land Collateral");

                return new Result { Saved = true, type = "Land" };
            }

            catch (Exception e)
            {
                log.Debug("Exception Occured While Saving Land Collateral");

                return new Result { Saved = false, type = e.Message };
            }
        }
    }
}
