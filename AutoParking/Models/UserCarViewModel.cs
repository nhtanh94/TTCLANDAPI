using AutoParking.Controllers;
using AutoParking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models
{
    public class UserCarViewModel : BaseController
    {
        public UserCar GetUserCar(string id,string Code)
        {             
            try
            {
                UserCar user;
                using(DB db  = new DB(Code))
                {
                     user = db.UserCars.Find(id);
                }
               
                return user;
            }

            catch
            {
            }
            return null;
        }
    }
}