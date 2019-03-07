using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class RequestCars
    {
        [Required]
        public string blockCode { set; get; }
        public DateTime fromDate { set; get; }
        public DateTime toDate { set; get; }
        public string idIn { set; get; }
        public string idOut { set; get; }
        public string Stt { set; get; }
        public string Bienso { set; get; }
    }
}