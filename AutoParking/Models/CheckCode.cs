using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models
{
    public class CheckCode
    {
       static List<string> _blockCode = new List<string> { "M1", "M2" };

        public static bool checkcode(string blockCode)
        {
            var check = _blockCode.Find(x => x == blockCode);
            if (check != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}