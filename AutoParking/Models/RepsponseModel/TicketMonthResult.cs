using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RepsponseModel
{
    public class TicketMonthResult
    {
        public int RowID { get; set; }
        public int Stt { get; set; }
        public string ID { get; set; }
        public System.DateTime ProcessDate { get; set; }
        public string Digit { get; set; }
        public string TenKH { get; set; }
        public string CMND { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CarKind { get; set; }
        public string IDPart { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public string Note { get; set; }
        public string Amount { get; set; }
        public string ChargesAmount { get; set; }
        public Nullable<int> Status { get; set; }
        public string Account { get; set; }
        public string Images { get; set; }
        public Nullable<System.DateTime> DayUnLimit { get; set; }
        public string Name { get; set; }
    }
}