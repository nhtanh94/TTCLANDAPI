using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class RequestSearchTicketMonthExpires
    {
        [Required]
        public string blockCode { get; set; }
        public string SearchString { get; set; }
    }
}