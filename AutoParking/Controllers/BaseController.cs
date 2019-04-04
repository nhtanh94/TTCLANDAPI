using AutoParking.Models;
using AutoParking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoParking.Entities;

namespace AutoParking.Controllers
{
    //[Authorize]
    public class BaseController : ApiController
    {
        //protected DB db = null;
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
