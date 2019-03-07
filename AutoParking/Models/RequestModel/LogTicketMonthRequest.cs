using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class LogTicketMonthRequest
    {
        public string blockCode { get; set; }
       public string tim { set; get; }
        public string ActionType { set; get; }
        public string loaixe { set; get; }
        public DateTime fromDate { set; get; }
        public DateTime toDate { set; get; }
    }
}