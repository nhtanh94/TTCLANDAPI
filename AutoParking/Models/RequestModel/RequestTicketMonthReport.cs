using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    /// <summary>
    /// XEM DOANH THU THEO MỐC THỜI GIAN
    /// </summary>
    public class RequestTicketMonthReport
    {
        [Required]
        public string blockCode { set; get; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }
}