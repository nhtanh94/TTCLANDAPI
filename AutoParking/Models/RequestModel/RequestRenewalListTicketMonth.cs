using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class RequestRenewalListTicketMonth
    {
        [Required]
        public int rowid { set; get; }
        [Required]
        public DateTime dateStart { set; get; }
        [Required]
        public DateTime dateEnd { set; get; }
    }
}