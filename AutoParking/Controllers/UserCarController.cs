using AutoParking.Entities;
using AutoParking.Models;
using AutoParking.Models.RepsponseModel;
using AutoParking.Models.RequestModel;
using AutoParking.Token;
using AutoParking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutoParking.Controllers
{
    public class UserCarController : BaseController
    {
        /// <summary>
        /// LẤY DANH SÁCH  NHÂN VIÊN
        /// </summary>
        /// <param name="blockCode">
        /// Code: Mã tòa nhà M1,M2
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/get-list-user")]
        public HttpResponseMessage GetListUser(string blockCode)
        {
            if (IsBodyNull(blockCode))
            {
                return ResponseFail(Constants.BODY_NOT_FOUND);
            }
            if (!CheckCode.checkcode(blockCode))
            {
                return ResponseFail(Constants.CODEERROR);
            }
            try
            {
                using(DB db = new DB(blockCode))
                {
                    var listUser = db.UserCars.Where(x => x.IDFunct.Equals("Nh")).Select(x => new UserCar
                    {
                        ID = x.ID,
                        NameUser =x.NameUser,
                        Account = x.Account,
                        Sex = x.Sex,
                        Working = x.Working,
                        IDFunct =  x.IDFunct
                    }).ToList();
                    return ResponseSuccess(listUser);
                }
               

              
            }
            catch
            {
                return ResponseFail(Constants.FAILD);
            }
        }

    }
}
