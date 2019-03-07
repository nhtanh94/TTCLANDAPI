using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models
{
    public class TicketMonthsLost
    {
        public int rowid { set; get; }
        public int stt { set; get; }
        public string id { set; get; }
        public string digit { set; get; }
        public string tenkh { set; get; }
        public string address { set; get; }
        public string partName { set; get; }
        public DateTime? datestart { set; get; }
        public DateTime? dateend { set; get; }
        public DateTime? dateLost { set; get; }
        public string note { set; get; }
        public string account { set; get; }
        public int status { set; get; }
        public  DateTime  DayUnLimit { set; get; }

    }
}