using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RepsponseModel
{
    public class ResponeLogTicketMonth
    {
        public int indentify { set; get; }
        public int? RowID { get; set; }

       
        public string ProcessType { get; set; }

       
        public string STT { get; set; }

        
        public string ID { get; set; }

     
        public DateTime DateProcess { get; set; }

      
        public string Digit { get; set; }

      
        public string TenKH { get; set; }

       
        public string CMND { get; set; }

      
        public string Company { get; set; }

      
        public string EMail { get; set; }

        
        public string Address { get; set; }

        public string CarKind { get; set; }

     
        public string IDPart { get; set; }

        
        public string DateStart { get; set; }

       
        public string DateEnd { get; set; }

        
        public string Note { get; set; }

        
        public string Amount { get; set; }

     
        public string ChargesAmount { get; set; }

       
        public string Account { get; set; }

       
        public string Images { get; set; }

     
        public string DayUnLimit { get; set; }

    }
}