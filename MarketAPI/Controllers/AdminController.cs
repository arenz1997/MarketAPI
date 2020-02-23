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
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// ADDS ITEM INTO STOCK
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns></returns>
        [HttpPost("AddItem")]
        public ActionResult AddItem(Item item)
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                Market.Items.Add(item);
                actionResult.Result = $"{item.description} added";
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
        /// EDITS ITEM IF IT EXISTS
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost("EditItem")]
        public ActionResult EditItem(Item item)
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                if (Market.Items.Contains(item))
                {
                    Item itemForEdit = Market.Items.FirstOrDefault(foundItem => foundItem.description == item.description);
                    itemForEdit.description = item.description;
                    itemForEdit.price = item.price;
                    itemForEdit.addedDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    actionResult.Result = $"{item.description} edited";
                }
                else
                    actionResult.Result = $"{item.description} not found";
                actionResult.ResultCode = ResultCodes.Normal;
                actionResult.ResultDescription = "Normal";
            }
            catch (Exception ex)
            {
                actionResult.Result = null;
                actionResult.ResultCode = ResultCodes.Error;
                actionResult.ResultDescription = ex.Message;
            }
            return actionResult;
        }

        /// <summary>
        /// REMOVES CURRENT ITEM
        /// </summary>
        /// <returns></returns>
        [HttpPost("RemoveItem")]
        public ActionResult RemoveItem(int id)
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                Item foundItem = Market.Items[id];
                Market.Items.Remove(foundItem);
                
                actionResult.Result = $"{foundItem.description} removed.";
                actionResult.ResultCode = ResultCodes.Normal;
                actionResult.ResultDescription = "Normal";
            }
            catch(Exception ex)
            {
                actionResult.Result = "Item not found";
                actionResult.ResultCode = ResultCodes.Error;
                actionResult.ResultDescription = ex.Message;
            }
            return actionResult;
        }

        /// <summary>
        /// ADDS EMPLOYEER
        /// </summary>
        /// <param name="employeer"></param>
        /// <returns></returns>
        [HttpPost("AddEmployeer")]
        public ActionResult AddEmployeer(Employeer employeer)
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                Market.Employeers.Add(employeer);
                actionResult.Result = $"{employeer.name + " " + employeer.surname} added with {employeer.salary} salary";
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