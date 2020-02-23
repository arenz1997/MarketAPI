using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ActionResult = MarketAPI.Models.ActionResult;
using ResultCodes = MarketAPI.Enumerations.ResultCodes;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        /// <summary>
        /// GETS MARKET'S INCOME
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetIncome")]
        public ActionResult GetIncome() 
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                if (Market.Income == 0)
                    actionResult.Result = "You haven't income";
                else
                    actionResult.Result = Market.Income;
                actionResult.ResultCode = ResultCodes.Normal;
                actionResult.ResultDescription = "Normal";
            }
            catch(Exception ex)
            {
                actionResult.Result = null;
                actionResult.ResultCode = ResultCodes.Error;
                actionResult.ResultDescription = ex.Message;
            }
            return actionResult;
        }

        /// <summary>
        /// GETS MARKET STOCK'S ITEMS
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetStock")]
        public ActionResult GetStock()
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                if (Market.Items.Count == 0)
                    actionResult.Result = "Stock is empty";
                else
                    actionResult.Result = Market.Items;
                actionResult.ResultCode = ResultCodes.Normal;
                actionResult.ResultDescription = "Normal";
            }
            catch(Exception ex)
            {
                actionResult.Result = null;
                actionResult.ResultCode = ResultCodes.Error;
                actionResult.ResultDescription = ex.Message;
            }
            return actionResult;
        }
    }
}