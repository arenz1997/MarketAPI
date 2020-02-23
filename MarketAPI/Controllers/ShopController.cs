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
    public class ShopController : ControllerBase
    {
        /// <summary>
        /// GETS CUSTOMER BAG'S ITEMS
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMyBagItems")]
        public ActionResult GetMyBagItems()
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                if (Customer.MyBagItems.Count == 0)
                    actionResult.Result = "My bag is empty";
                else
                    actionResult.Result = Customer.MyBagItems; 
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
        /// BUY ITEM
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("BuyItem")]
        public ActionResult BuyItem(int id)
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                Item foundItem = Market.Items[id];
                if(Customer.Money >= foundItem.price)
                {
                    Market.Items.Remove(foundItem);
                    Market.Income += foundItem.price;
                    foundItem.addedDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    Customer.MyBagItems.Add(foundItem);
                    Customer.Money -= foundItem.price;
                    actionResult.Result = $"You have bought {foundItem.description} with {foundItem.price} AMD";
                }
                else
                {
                    actionResult.Result = $"You can't buy {foundItem.description} with {foundItem.price} AMD, because you have {Customer.Money} AMD";
                }
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