using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class RequestDeleteBlackCard : RequestDeleteTicketMonth
    {
        public string ID { set; get; }
    }
}