using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Models
{
    public class ActionResult
    {
        public object Result { get; set; }
        public Enumerations.ResultCodes ResultCode { get; set; }
        public string ResultDescription { get; set; }
    }
}
