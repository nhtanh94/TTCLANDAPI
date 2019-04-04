using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RepsponseModel
{
    public class CardReport
    {
        public int Total { get; set; }
        public int TotalTicketMonthUsing { get; set; }
        public int TotalCreateNew { get; set; }
        public int TotalStopUsingTicketMonth { get; set; }
        public int TotalBlackTicketMonth { get; set; }
    }
}