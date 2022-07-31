using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementModule.Models
{
    public class LoanManagementDbContext: DbContext
    {
        public LoanManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Collateral> Collaterals { get; set; }
        public DbSet<CustomersLoan> CustomersLoans { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Customer>()
                .HasData(
                    new Customer
                    {
                        CustomerId=1,
                       CustomerFirstName="Saicharan",
                       CustomerLastName="M",
                       CustomerAge=21,
                       CustomerPhoneNumber=8317670705,
                       CustomerAccountNumber=1301567
                    },
                     new Customer
                     {
                         CustomerId = 2,
                         CustomerFirstName = "George",
                         CustomerLastName = "Antony",
                         CustomerAge = 21,
                         CustomerPhoneNumber = 7337004089,
                         CustomerAccountNumber = 1501322
                     },
                      new Customer
                      {
                          CustomerId = 3,

                          CustomerFirstName = "Varun",
                          CustomerLastName = "Raj",
                          CustomerAge = 21,
                          CustomerPhoneNumber = 9312456892,
                          CustomerAccountNumber = 1439087
                      },
                       new Customer
                       {
                           CustomerId = 4,

                           CustomerFirstName = "Vivek",
                           CustomerLastName = "Boppudi",
                           CustomerAge = 21,
                           CustomerPhoneNumber = 6303129879,
                           CustomerAccountNumber = 1209873
                       },
                       new Customer
                       {
                          CustomerId=5,
                          CustomerFirstName="Ram",
                          CustomerLastName="Raj",
                          CustomerAge=45,
                          CustomerPhoneNumber=6324143454,
                          CustomerAccountNumber=1908765
                       },
                       new Customer
                       {
                          CustomerId=6,
                          CustomerFirstName="Srujana",
                          CustomerLastName="K",
                          CustomerAge=35,
                          CustomerPhoneNumber=9808997761,
                          CustomerAccountNumber=2010201
                       },
                          new Customer
                       {
                          CustomerId=7,
                          CustomerFirstName="Chandan",
                          CustomerLastName="M",
                          CustomerAge=27,
                          CustomerPhoneNumber=7665663241,
                          CustomerAccountNumber=1788765
                       }
                       );


            modelBuilder.Entity<Loan>().HasData(
                new Loan
                {
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
                   new Loan
                   {
                       LoanId = 4,

                       LoanName = "Loan4",
                       LoanMaxAmount = 10000000,
                       Interest = 8.9,
                       LoanTenureInYears = 9,
                       TypeOfCollateralAccepted = "Land"
                   }
                );


            modelBuilder.Entity<Collateral>().HasData(
                new Collateral
                {
                    Id=1,
                    Description = "50 gms of gold Bought in January 2017 From KK Jewellery in Hyderabad"
                },
                new Collateral
                {
                    Id = 2,
                    Description = "3000 sq feet Land Located in Anantapur Bought in 2015 From JJ Properties, Now with Coconut Plantation"
                },
                new Collateral
                {
                    Id = 3,
                    Description = "1500 sq feet Two storeyed House with Two Bedrooms built in 2010 located in Hyderabad"
                },
                new Collateral
                {
                    Id = 4,
                    Description = "3500 sq feet Land Located in KR puram Bangalore Bought in 2010 from private owner ,Now with Banana Plantation"
                },
                new Collateral
                {
                    Id = 5,
                    Description = "70 gms of gold bought in 2019 From JO Jewellary in Chennai"
                },
                new Collateral
                {
                    Id = 6,
                    Description = "2000 sq feet Three storeyed home built in 2007 located in Sarjapur Bangalore Bought from private owner"
                },
                 new Collateral
                 {
                     Id = 7,
                     Description = "400 gms of gold bought in 2010 from RR Jewellary Coimbatore"
                 }
                );

            modelBuilder.Entity<CustomersLoan>().HasData(
                new CustomersLoan
                {
                    CustomerLoanId=1,
                    SanctionedAmount=2000000,
                    IsCollateraled=false,
                    CustomerId=2,
                    LoanId=3,
                    CollateralId=3,
                    EMI=30000
                },
                new CustomersLoan
                {
                    CustomerLoanId = 2,
                    SanctionedAmount = 300000,
                    IsCollateraled = false,
                    CustomerId = 3,
                    LoanId = 1,
                    CollateralId = 1,
                    EMI = 4300
                },
                new CustomersLoan
                {
                    CustomerLoanId = 3,
                    SanctionedAmount = 700000,
                    IsCollateraled = false,
                    CustomerId = 4,
                    LoanId = 2,
                    CollateralId = 2,
                    EMI = 8400
                },
                new CustomersLoan
                {
                    CustomerLoanId = 4,
                    SanctionedAmount = 5000000,
                    IsCollateraled = false,
                    CustomerId = 1,
                    LoanId = 4,
                    CollateralId = 4,
                    EMI = 46400
                },
                new CustomersLoan
                {
                    CustomerLoanId = 5,
                    SanctionedAmount = 400000,
                    IsCollateraled = false,
                    CustomerId = 7,
                    LoanId = 2,
                    CollateralId = 5,
                    EMI = 5300
                },
                new CustomersLoan
                {
                       CustomerLoanId = 6,
                       SanctionedAmount = 1000000,
                       IsCollateraled = false,
                       CustomerId = 5,
                       LoanId = 3,
                       CollateralId = 6,
                       EMI = 10000
                },
                new CustomersLoan
                {
                    CustomerLoanId = 7,
                    SanctionedAmount = 2500000,
                    IsCollateraled = false,
                    CustomerId = 6,
                    LoanId = 4,
                    CollateralId = 7,
                    EMI = 30000
                }
                );


        }


    }
}
