
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RepsponseModel
{
    public class ResponseLogin
    {
        public string ID { get; set; }
        public string Account { get; set; }
        public string NameUser { get; set; }
        //public bool Sex { get; set; }
        //public bool? Working { get; set; }
        //public string IDFunct { get; set; }

        
        public string Token { get; set; }
    }
}