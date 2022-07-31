using NUnit.Framework;
using System.Text.Json;
using System;
using Microsoft.EntityFrameworkCore;
using CollateralManagement.Models;
using Moq;
using CollateralManagement.Repository;
using CollateralManagement.OutputModels;
using System.Threading.Tasks;
using CollateralManagement.Controllers;
using CollateralManagement.SaveCollateralHelper;
using Newtonsoft.Json.Linq;

namespace UnitTestForCollateralManagementService
{
    [TestFixture]
    public class Tests
    {
        DbContextOptions options;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<CollateralDbContext>().UseInMemoryDatabase(databaseName: "CollateralDB").Options;

            using (var context = new CollateralDbContext((DbContextOptions<CollateralDbContext>)options))
            {
                context.Database.EnsureDeleted();
            }
        }

        [Test]
        public void TestSavingController()
        {
            using (var context = new CollateralDbContext((DbContextOptions<CollateralDbContext>)options))
            {
                Result res = new Result();
                res.Saved = true;
                res.type = "House";

                Mock<IClassification> classificationMock = new Mock<IClassification>();
                classificationMock.Setup(p => p.ClassifyPostedCollateralType(It.IsAny<JsonElement>())).Returns(Task.FromResult(res));

                Mock<IDatabaseSaver> dataServiceMock = new Mock<IDatabaseSaver>();
                dataServiceMock.Setup(p => p.GetCollateralDetailsFromSpecificTable(It.IsAny<int>())).Returns(new RiskOutputModel());

                var controllerobj = new CollateralManagementController(classificationMock.Object, dataServiceMock.Object);

                string jsonvalues = @"{
                    ""LoanId"": 2,
                    ""CustomerId"": 4,
                    ""CollateralId"": 4,
                    ""HouseOwner"": ""George"",
                   ""HouseAddress"": ""bob"",
                    ""HouseArea"": 5000,
                    ""HouseYear"": 2021,
                    ""HouseCurrentValue"": 3000000,
                    ""HouseDepricationRate"": 12,
                    ""CollateralType"": ""House"",
                    ""HousePledgedDate"": ""12/12/1999"",
                    ""HouseCurrentStructureValue"": 500000
                    }
                ";

                JsonDocument jsonDocument = JsonDocument.Parse(jsonvalues);
                JsonElement jsonElement = jsonDocument.RootElement;
                Console.WriteLine(jsonElement);

                bool result;
                result = controllerobj.SaveCollateralAsync(jsonElement).Result.Saved;

                Assert.AreEqual(true, result);
            }


            
        }

        [TestCase("Land")]
        [TestCase("House")]
        [TestCase("Gold")]
        [TestCase("Cash")]
        public void TestRequestClassifierWithType(string type)
        {
            Mock<IDatabaseSaver> dataServiceMock = new Mock<IDatabaseSaver>();
            string jsonvalues;

            if (type == "House")
            {
                dataServiceMock.Setup(p => p.SaveHouseCollateralAsync(It.IsAny<JObject>())).Returns(Task.FromResult(new Result() { Saved = true, type = "House" }));
                 jsonvalues = @"{
                    ""LoanId"": 2,
                    ""CustomerId"": 4,
                    ""CollateralId"": 4,
                    ""HouseOwner"": ""George"",
                   ""HouseAddress"": ""bob"",
                    ""HouseArea"": 5000,
                    ""HouseYear"": 2021,
                    ""HouseCurrentValue"": 3000000,
                    ""HouseDepricationRate"": 12,
                    ""CollateralType"": ""House"",
                    ""HousePledgedDate"": ""12/12/1999"",
                    ""HouseCurrentStructureValue"": 500000
                    }
                ";
            }
            else if (type == "Land")
            {
                dataServiceMock.Setup(p => p.SaveLandCollateralAsync(It.IsAny<JObject>())).Returns(Task.FromResult(new Result() { Saved = true, type = "Land" }));
                 jsonvalues = @"{
                    ""LoanId"": 2,
                    ""CustomerId"": 4,
                    ""CollateralId"": 4,
                    ""HouseOwner"": ""George"",
                   ""HouseAddress"": ""bob"",
                    ""HouseArea"": 5000,
                    ""HouseYear"": 2021,
                    ""HouseCurrentValue"": 3000000,
                    ""HouseDepricationRate"": 12,
                    ""CollateralType"": ""Land"",
                    ""HousePledgedDate"": ""12/12/1999"",
                    ""HouseCurrentStructureValue"": 500000
                    }
                ";
            }
            else if(type == "Gold")
            {
                dataServiceMock.Setup(p => p.SaveGoldCollateralAsync(It.IsAny<JObject>())).Returns(Task.FromResult(new Result() { Saved = true, type = "Gold" }));
                 jsonvalues = @"{
                    ""LoanId"": 2,
                    ""CustomerId"": 4,
                    ""CollateralId"": 4,
                    ""HouseOwner"": ""George"",
                   ""HouseAddress"": ""bob"",
                    ""HouseArea"": 5000,
                    ""HouseYear"": 2021,
                    ""HouseCurrentValue"": 3000000,
                    ""HouseDepricationRate"": 12,
                    ""CollateralType"": ""Gold"",
                    ""HousePledgedDate"": ""12/12/1999"",
                    ""HouseCurrentStructureValue"": 500000
                    }
                ";
            }
            else
            {
                jsonvalues = @"{
                    ""LoanId"": 2,
                    ""CustomerId"": 4,
                    ""CollateralId"": 4,
                    ""HouseOwner"": ""George"",
                   ""HouseAddress"": ""bob"",
                    ""HouseArea"": 5000,
                    ""HouseYear"": 2021,
                    ""HouseCurrentValue"": 3000000,
                    ""HouseDepricationRate"": 12,
                    ""CollateralType"": ""NotValid"",
                    ""HousePledgedDate"": ""12/12/1999"",
                    ""HouseCurrentStructureValue"": 500000
                    }
                ";
            }
            var requestClassifier = new CollateralClassification(dataServiceMock.Object);

            

            JsonDocument jsonDocument = JsonDocument.Parse(jsonvalues);
            JsonElement jsonElement = jsonDocument.RootElement;
            Console.WriteLine(jsonElement);
            
            var result = requestClassifier.ClassifyPostedCollateralType(jsonElement).Result.Saved;
            if((type=="Land")|| (type == "House")|| (type == "Gold"))
            Assert.AreEqual(true, result);
            else
            Assert.AreEqual(false, result);
        }


    
    }


}