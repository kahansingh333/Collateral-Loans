using LoanManagementModule.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using LoanManagementModule.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementModule.Repository
{
    // Repo to get All the Sanctioned Loan Details 
    public class LoanManagementrepo : ILoanManagement
    {


        LoanManagementDbContext db;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LoanManagementrepo(LoanManagementDbContext _db)
        {
            db = _db;
        }

        //After the Collateral Saved
        
        public void CollateralsSaved(int LoanId)
        {
            log.Info("Collateral Successfully Saved");
            db.CustomersLoans.SingleOrDefault(c => c.CustomerLoanId == LoanId).IsCollateraled = true;
            db.SaveChanges();
        }

        //Retrieving All the Sanctioned Loans
        public List<AllDetail> GetSanctionedLoans()
        {
            var DataAboutLoans = db.CustomersLoans.Include(cl => cl.Customer).Include(c=>c.Collateral).ToList();
            List<AllDetail> Result = new List<AllDetail>();
            log.Debug(" Sanctioned Loans Data Fetched from the Database");
            return ReturnResult(DataAboutLoans);
        }


        public List<AllDetail> GetSanctionedLoansById(int LoanId, int CustomerId)
        {
            var DataAboutLoans = db.CustomersLoans.Include(cl => cl.Customer).Include(c => c.Collateral).Where(x=>x.CustomerId==CustomerId && x.CustomerLoanId==LoanId).ToList();
            log.Debug(" Sanctioned Loans Search Result Fetched from the Database");

            return ReturnResult(DataAboutLoans);
        }


        public List<AllDetail> ReturnResult(IEnumerable<CustomersLoan> DataAboutLoans)
        {
            List<AllDetail> Result = new List<AllDetail>();
            foreach (var customerloan in DataAboutLoans)
            {
                AllDetail Temp = new AllDetail();
                Temp.LoanId = customerloan.CustomerLoanId;
                Temp.Name = customerloan.Customer.CustomerFirstName;
                Temp.SanctionedLoan = customerloan.SanctionedAmount;
                Temp.CollateralId = customerloan.Collateral.Id;
                Temp.ISCollateralIssued = customerloan.IsCollateraled;
                Temp.EMI = customerloan.EMI;
                Temp.CustomerId = customerloan.Customer.CustomerId;
                Temp.AccountNumber = customerloan.Customer.CustomerAccountNumber;
                Temp.CollateralDescription = customerloan.Collateral.Description;
                // res.ISCollateralIssued = 
                Result.Add(Temp);
            }
            log.Debug(" Data mapped according to the requirement as All Details");

            return Result;
        }





    }
}
