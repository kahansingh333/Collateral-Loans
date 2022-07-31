using LoanManagementModule.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementModule.Repository
{
    public interface ILoanManagement
    {
        public List<AllDetail> GetSanctionedLoans();

        public List<AllDetail> GetSanctionedLoansById(int LoanId,int CustomerId);
        public void CollateralsSaved(int LoanId);
    }
}
