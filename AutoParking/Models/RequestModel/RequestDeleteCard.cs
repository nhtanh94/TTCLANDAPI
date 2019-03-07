using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class RequestDeleteCard
    {
        [Required]
        public string blockCode { set; get; }
        [Required]
        public string ID { set; get; }
    }
}