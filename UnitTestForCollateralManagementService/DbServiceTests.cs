using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CollateralManagement.Collateral;
using CollateralManagement.Models;
using CollateralManagement.OutputModels;
using CollateralManagement.SaveCollateralHelper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace UnitTestForCollateralManagementService
{
    [TestFixture]
    class DbServiceTests
    {
        DbContextOptions options;

        [SetUp]
        public void Setup()
        {

            options = new DbContextOptionsBuilder<CollateralDbContext>().UseInMemoryDatabase(databaseName: "CollateralDB").Options;

        }

        [TearDown]
        public void teardown()
        {
            using (var context = new CollateralDbContext((DbContextOptions<CollateralDbContext>)options))
            {
                context.Database.EnsureDeleted();
            }
        }

        [TestCase("House")]
        [TestCase("Land")]
        [TestCase("Gold")]

        public void TestSavingCollateral(string type)
        {
            JObject y = JObject.Parse("{ 'LoanId': 2}");
            y["CustomerId"] = 4;
            y["CollateralId"] = 4;

            if (type == "House")
            {
                y["HouseOwner"] = "GEoreg";
                y["HouseAddress"] = "Bob";
                y["HouseArea"] = 5000;
                y["HouseYear"] = 2021;
                y["HouseCurrentvalue"] = 3000000;
                y["HouseDeprecationRate"] = 12;
                y["HousePledgedDate"] = "09/09/2021";
                y["HouseCurrentStructureValue"] = 500000;
            }
            else if(type == "Land")
            {
                y["LandOwner"] = "George";
                y["LandAddress"] = "Bob";
                y["LandArea"] = 5000;
                y["Pricepersquarefeet"] = 2021;
                y["YearInLandBought"] = 3000000;
                y["LandDepriciationRate"] = 12;
                y["LandPledgedDate"] = "09/09/2021";
                y["PropertyYear"] = 2009;
                y["LandCurrentvalue"] = 2009;

            }
            else if (type == "Gold")
            {
                y["GoldOwner"] = "George";
                y["Weight"] = 5000;
                y["YearInGoldBought"] = 2021;
                y["GoldValue"] = 3000000;
                y["GoldDepriciationRate"] = 12;
                y["GoldPledgedDate"] = "09/09/2021";
            }

            using (CollateralDbContext context = new CollateralDbContext((DbContextOptions<CollateralDbContext>)options))
            {

                bool result;

                CollateralDBWorker dbSaver = new CollateralDBWorker(context);
                if (type == "House")
                    result = dbSaver.SaveHouseCollateralAsync(y).Result.Saved;
                else if (type == "Land")
                    result = dbSaver.SaveLandCollateralAsync(y).Result.Saved;
                else if (type == "Gold")
                    result = dbSaver.SaveGoldCollateralAsync(y).Result.Saved;
                else
                {
                    result = false;
                }

                Assert.AreEqual(true, result);
               

            }
        }
    }
}
