using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RepsponseModel
{
    public class ResponseTicketMonthReport
    {
        public int Quantity { set; get; }
        public int Price { set; get; }
        public List<TicketMonthResult> TicketMonths { set; get; }
    }
}