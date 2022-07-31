using LoanManagementModule.Controllers;
using LoanManagementModule.Models;
using LoanManagementModule.OutputModels;
using LoanManagementModule.Repository;
using LoanManagementModule.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanManagementServiceTests
{
    [TestFixture]
    public class Tests
    {
        List<Customer> Customers;
        List<Loan> Loans;
        List<Collateral> Collaterals;
        List<CustomersLoan> CustomerLoans;
        List<AllDetail> Result;
        DbContextOptions options;
       
       

        [SetUp]
        public  void Setup()
        {
            
            Customers = new List<Customer>
            {
                new Customer{CustomerId=1,CustomerAccountNumber=151327,CustomerAge=22,CustomerFirstName="Saicharan Kalyan Reddy",CustomerLastName="M",CustomerPhoneNumber=8317670705},

                new Customer{CustomerId=2,CustomerAccountNumber=141327,CustomerAge=21,CustomerFirstName="Haran",CustomerLastName="M",CustomerPhoneNumber=7337004089},
                new Customer{CustomerId=3,CustomerAccountNumber=131234,CustomerAge=23,CustomerFirstName="Chandan",CustomerLastName="M",CustomerPhoneNumber=15516893014},

            };
            Loans = new List<Loan>
            {
                  new Loan{
                    LoanId=1,
                    LoanName = "Loan1",
                    LoanMaxAmount = 500000,
                    Interest = 5.9,
                    LoanTenureInYears = 6,
                    TypeOfCollateralAccepted = "Gold House"
                },
                  new Loan
                 {
                     LoanId = 2,

                     LoanName = "Loan2",
                     LoanMaxAmount = 1500000,
                     Interest = 7.8,
                     LoanTenureInYears = 7,
                     TypeOfCollateralAccepted = "Gold Land House"
                 },
                  new Loan
                  {
                      LoanId = 3,

                      LoanName = "Loan3",
                      LoanMaxAmount = 5000000,
                      Interest = 8.3,
                      LoanTenureInYears = 8,
                      TypeOfCollateralAccepted = "Land House"
                  },



            };

            Collaterals = new List<Collateral>
            {
                  new Collateral
                {
                    Id = 1,
                    Description = "3000 sq feet Land Located in Anantapur Bought in 2015"
                },
                new Collateral
                {
                    Id = 2,
                    Description = "1500 sq feet of home built in 2010 located in Hyderabad"
                },
                new Collateral
                {
                    Id = 3,
                    Description = "3500 sq feet Land Located in Bangalore Bought in 2010"
                }

            };

            CustomerLoans = new List<CustomersLoan>
            {
                 new CustomersLoan
                {
                    CustomerLoanId=1,
                    SanctionedAmount=2000000,
                    IsCollateraled=false,
                    CustomerId=1,
                    LoanId=1,
                    CollateralId=1,
                    EMI=30000
                },
                 new CustomersLoan
                {
                    CustomerLoanId = 2,
                    SanctionedAmount = 700000,
                    IsCollateraled = false,
                    CustomerId = 3,
                    LoanId = 2,
                    CollateralId = 2,
                    EMI = 8400
                },
                new CustomersLoan
                {
                    CustomerLoanId = 3,
                    SanctionedAmount = 5000000,
                    IsCollateraled = false,
                    CustomerId = 2,
                    LoanId = 3,
                    CollateralId = 3,
                    EMI = 46400
                }


            };
       

            options = new DbContextOptionsBuilder<LoanManagementDbContext>()
           .UseInMemoryDatabase(databaseName: "LoanManagementService")
           .Options;
            using (var context = new LoanManagementDbContext(options))
            {
                 context.Customers.AddRangeAsync(Customers);
                 context.Loans.AddRangeAsync(Loans);
                 context.Collaterals.AddRangeAsync(Collaterals);
                 context.CustomersLoans.AddRangeAsync(CustomerLoans);

                 context.SaveChangesAsync();

            }
        }

        [TearDown]
        public void CleanDatabase()
        {
            using (var context = new LoanManagementDbContext(options))
            {
                context.Database.EnsureDeleted();
            }
        }

     
        [TestCase(1,1)]
        public void TestLoanMAnagementController(int LoanId,int CustomerId)
        {
            List<AllDetail> NullObj = new List<AllDetail>();
            Mock<ILoanManagement> MockRepo = new Mock<ILoanManagement>();
            Mock<ICollateralService>  MockService = new Mock<ICollateralService>();

            MockRepo.Setup(p => p.GetSanctionedLoans()).Returns((NullObj));

            MockRepo.Setup(p => p.GetSanctionedLoansById(It.IsAny<int>(), It.IsAny<int>())).Returns(NullObj);


            LoanManagementController Controller = new LoanManagementController(MockRepo.Object, MockService.Object);

            var SanctionedLoans = Controller.GetSanctionedLoans();

            var SanctionedLoansById = Controller.GetSanctionedLoansById(LoanId,CustomerId);



            Assert.IsInstanceOf<List<AllDetail>>(SanctionedLoansById);

            Assert.IsInstanceOf<List<AllDetail>>(SanctionedLoans);
        }


        [TestCase(1,1, 151327)]
        public void TestGetSanctionedLoans(int CustomerId,int CollateralId,long AccountNumber)
        {
          

            using (var context = new LoanManagementDbContext(options))
            {

                Mock<ILoanManagement> MockRepo = new Mock<ILoanManagement>();

                MockRepo.Setup(p => p.GetSanctionedLoans()).Returns(Result);
                LoanManagementrepo LoanRepo = new LoanManagementrepo(context);

                List<AllDetail> SanctionedLoans = LoanRepo.GetSanctionedLoans();

              
                AllDetail Model1 = SanctionedLoans[0];

                Assert.IsInstanceOf<List<AllDetail>>(SanctionedLoans);

                Assert.AreEqual(Model1.CustomerId, CustomerId);

                Assert.AreEqual(Model1.CollateralId, CollateralId);

                Assert.AreEqual(Model1.AccountNumber, AccountNumber);

            }

        }


        [TestCase(2, 3,2)]
        [TestCase(3,2,3)]
        [TestCase(1, 1, 1)]

        public void TestGetLoanDetailsById(int LoanId, int CustomerId,int CollateralId)
        {
            using (var context = new LoanManagementDbContext(options))
            {

                Mock<ILoanManagement> MockRepo = new Mock<ILoanManagement>();

                MockRepo.Setup(p => p.GetSanctionedLoansById(It.IsAny<int>(),It.IsAny<int>())).Returns(Result);
                LoanManagementrepo LoanRepo = new LoanManagementrepo(context);

                List<AllDetail> SanctionedLoans = LoanRepo.GetSanctionedLoansById(LoanId,CustomerId);


                Assert.IsInstanceOf<List<AllDetail>>(SanctionedLoans);

                Assert.AreEqual(CollateralId, SanctionedLoans[0].CollateralId);


            }
        }



    }
}