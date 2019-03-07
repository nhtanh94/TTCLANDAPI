using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models
{
    public class TicketMonthsExpires
    {
        public int rowid { set; get; }
        public int stt { set; get; }
        public string id { set; get; }
        public string digit { set; get; }
        public string tenkh { set; get; }
        public string cmnd { set; get; }
        public string company { set; get; }
        public string email { set; get; }
        public string image { set; get; }
        public string address { set; get; }
        public string amount { set; get; }
        public string chargesamount { set; get; }
        public string note { set; get; }
        public string status { set; get; }
        public int songay { set; get; }
        public DateTime datestart { set; get; }
        public DateTime dateend { set; get; }
        public string account { set; get; }
    }
}