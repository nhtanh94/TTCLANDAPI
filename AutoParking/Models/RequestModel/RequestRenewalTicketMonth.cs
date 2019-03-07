using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class RequestRenewalTicketMonth
    {
        [Required]
        public string Code { set; get; }
        [Required]
        public List<string> rowid { set; get; }
        [Required]
        public DateTime dateStart { set; get; }
        [Required]
        public DateTime dateEnd { set; get; }

        /// <summary>
        /// Id người gia hạn
        /// </summary>
        public string AccountID { set; get; }
    }
}