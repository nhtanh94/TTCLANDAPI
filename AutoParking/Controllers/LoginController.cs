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
    public class LoginController : ApiController
    {


        /// <summary>
        /// LOGIN LẤY THÔNG TIN TÀI KHOẢN VÀ TOKEN
        /// </summary>
        /// <param name="request">
        /// Token dùng để chứng thực và hết hạn sau 30 ngày.
        /// Khi gọi api kèm theo header author
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/login")]
        public HttpResponseMessage Login([FromBody] RequestLogin request)
        {
            if (IsBodyNull(request))
            {
                return ResponseFail(Constants.NOT_FOUND);
            }
          

            try
            {
                UserCar user;
                using (DB db = new DB("M2"))
                {
                    user = db.UserCars.SingleOrDefault(x => x.NameUser.Equals(request.Username) && x.Pass.Equals(request.Password));
                }




                if (user != null)
                {

                    var token = TokenManager.GenerateTokenKey(user.Account);
                    var reponseLogin = new ResponseLogin()
                    {
                        ID = user.ID,
                        Account = user.Account,
                        //IDFunct = user.IDFunct,
                        NameUser = user.NameUser,
                        //Sex = user.Sex,
                        //Working = user.Working,
                        Token = token,
                    };

                    return ResponseSuccess(reponseLogin);
                }

            }
            catch
            {
                return ResponseFail(Constants.MSG_ERROR_LOGIN);
            }
            return ResponseFail(Constants.MSG_ERROR_LOGIN);


        }


        protected HttpResponseMessage ResponseFail(string msg)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_FAIL, msg));
        }

        protected HttpResponseMessage ResponseFail(string msg, object data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_FAIL, msg, data));
        }

        protected HttpResponseMessage ResponseSuccess(string msg)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_SUCCESS, msg));
        }
        protected HttpResponseMessage ResponseSuccess(string msg, object data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_SUCCESS, msg, data));
        }

        protected HttpResponseMessage ResponseSuccess()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_SUCCESS, Constants.SUCCESS));
        }

        protected HttpResponseMessage ResponseSuccess(object data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_SUCCESS, Constants.SUCCESS, data));
        }

        protected bool IsBodyNull(object body)
        {
            return body == null;
        }

        private HttpResponseMessage ResponseFail()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(Constants.ERROR_CODE_FAIL, Constants.FAILD));
        }
    }
}
