using CollateralManagement.Collateral;
using CollateralManagement.OutputModels;
using CollateralManagement.Repository;
using CollateralManagement.SaveCollateralHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

         /*
            Controller for saving collateral into types and for sending collateral details
            requester (Loan Management API)...
        */

namespace CollateralManagement.Controllers
{
    [ApiController]
    public class CollateralManagementController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IClassification repo;
        private readonly IDatabaseSaver db;

        public CollateralManagementController(IClassification _repo, IDatabaseSaver _db)
        {
            repo = _repo;
            db = _db;
        }

        [HttpPost]
        [Route("SaveCollateral")]

        //For saving the collaterals into its specific types
        //Called by the @@@@Loan Management API after form submission
        public async Task<Result> SaveCollateralAsync([FromBody] JsonElement element)
        {
            log.Debug("Entered Controller to Save the Collateral Data Recieved from Loan Management Service");
            //Call collateral type classifier which then saves it to the db
            return await repo.ClassifyPostedCollateralType(element);
        }

        [HttpGet("GetCollateral/{collateralid}")]
      
        //For providing collateral details of a specific loan
        //Called by the @@@@Risk Assesment API when risk analysis is clicked on a specific loan
        public string GetCollaterals(int collateralid)
        {
            log.Debug("Entered Controller to Get the Collateral Data");
            return System.Text.Json.JsonSerializer.Serialize(db.GetCollateralDetailsFromSpecificTable(collateralid));
        }
    }
}
