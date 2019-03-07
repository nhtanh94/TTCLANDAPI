using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models
{
    public class ResponseData
    {
        public int errorCode { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public ResponseData(int errorCode, string message)
        {
            this.errorCode = errorCode;
            this.message = message;
            this.data = null;
        }

        public ResponseData(int errorCode, string message, object data)
        {
            this.errorCode = errorCode;
            this.message = message;
            this.data = data;
        }

    }
}