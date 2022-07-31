using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using LoanManagementModule.Repository;
using LoanManagementModule.Models;
using LoanManagementModule.Services;
using LoanManagementModule.OutputModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Cors;

namespace LoanManagementModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [EnableCors]
    public class LoanManagementController : ControllerBase
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /*
       ENDpOINTS: 
            -GetSactionedLoans 
            -Send Collaterals Data to Collateral Management Service
       */

        ILoanManagement repo;
        ICollateralService service;

        public LoanManagementController(ILoanManagement _repo,ICollateralService _service)
        {
           
            repo = _repo;
            service = _service;
        }

        
        //GetSanctionedLoans
        [HttpGet("getsanctionedloans")]
        public List<AllDetail> GetSanctionedLoans()
        {
            log.Debug("Entered the Controller to retrieve all the Sanctioned Loans");
            return repo.GetSanctionedLoans();
        }
        //Get Loan Details Based on Customer Id And LoanId
        [HttpGet("getsanctionedloans/{LoanId}/{CustomerId}")]
        public List<AllDetail> GetSanctionedLoansById(int LoanId,int CustomerId)
        {
            log.Debug("Entered the Controller to retrieve the Search result based on the id");

            return repo.GetSanctionedLoansById(LoanId,CustomerId);
        }

        //Save the Collateral Details

        [HttpPost("savecollateral")]
        public  string  SaveCollateral([FromBody] JsonElement value)
        {
            log.Debug("Entered the Controller to Send Collateral Data to Collateral Management Service");


            var Collateral =  service.SaveCollateralAsync(value).Result;

            JObject JsonObject = JObject.Parse(Collateral.ToString());

            var CollateralDetails = JObject.Parse(value.ToString());

            var LoanId = Int32.Parse(CollateralDetails["LoanId"].ToString());

            if (bool.Parse(JsonObject["saved"].ToString()))
            {
                repo.CollateralsSaved(LoanId);
            }
            else
            {
                log.Debug("Collateral Data is Not Successfully Saved");

            }

            return JsonObject.ToString();
        }

   

    }
}
