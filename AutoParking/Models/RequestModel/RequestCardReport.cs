using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class RequestCardReport
    {
        public DateTime fromDate { set; get; }
        public DateTime toDate { set; get; }
    }
}