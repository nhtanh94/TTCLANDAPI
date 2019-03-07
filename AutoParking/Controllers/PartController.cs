using AutoParking.Entities;
using AutoParking.Models;
using AutoParking.Models.RequestModel;
using AutoParking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutoParking.Controllers
{
    public class PartController : BaseController
    {
        /// <summary>
        /// LẤY DANH SÁCH LOẠI XE
        /// </summary>
        ///Code : Mã tòa nhà M1,M2
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/list-part")]
        public HttpResponseMessage GetListPart()
        {
            List<object> listPart = new List<object>();
            try
            {
             
                IEnumerable<object> listPartM1;
                IEnumerable<object> listPartM2;
                using (DB db = new DB("M1"))
                {
                    listPartM1 = db.Parts.Select(x=> new { ID =x.ID,Name =x.Name, Amount = x.Amount, Sign = x.Sign, Limit = x.Limit,blockCode ="M1" }).ToList();
                 }
                using (DB db = new DB("M2"))
                {
                    listPartM2= db.Parts.Select(x => new { ID = x.ID, Name = x.Name, Amount = x.Amount, Sign = x.Sign, Limit = x.Limit, blockCode = "M2" }).ToList();
                }
                listPart.AddRange(listPartM1.ToList());
                listPart.AddRange(listPartM2.ToList());

                return ResponseSuccess(listPart);
            }
            catch
            {
                return ResponseFail(Constants.FAILD);
            }         
           
        }
        [HttpGet]
        [Route("api/v1/sreach-part")]
        public HttpResponseMessage GeIDPart(string blockCode ,string Name)
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
                using (DB db = new DB(blockCode))
                {
                  var kq =  db.Parts.Where(x => x.Name == Name).Select(x => new { Id = x.ID}).Single();
                    return ResponseSuccess(kq);
                }


            }
            catch
            {
                return ResponseFail(Constants.FAILD);
            }
        }
    }
}
