using AutoParking.Entities;
using AutoParking.Models;
using AutoParking.Models.RepsponseModel;
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
    public class LogTicketMonthController : BaseController
    {

        [HttpPost]
        [Route("api/v1/list-log-ticketmonth")]
        public HttpResponseMessage GetListLogTicketMonth([FromBody] LogTicketMonthRequest request)
        {

            if (IsBodyNull(request))
            {
                return ResponseFail(Constants.BODY_NOT_FOUND);
            }
            if (request.fromDate > request.toDate)
            {
                return ResponseFail(Constants.MSG_ERROR_DATE);
            }
            
            if (!CheckCode.checkcode(request.blockCode))
            {
                return ResponseFail(Constants.CODEERROR);
            }
            string str1 = "";
            string str2 = "";
            string str3 = "";
            if (request.tim != "" && request.tim != null)
                str3 = " and (id = '" + request.tim + "' or digit like N'%" + request.tim + "%' or dateStart ='" + request.tim + "' or dateEnd ='" + request.tim + "' or tenkh like N'%" + request.tim + "%' or company like N'%" + request.tim + "%' or address like N'%" + request.tim + "%' or carkind like N'%" + request.tim + "%' or chargesAmount = '" + request.tim + "' or amount ='" + request.tim + "' or stt = '" + request.tim + "' or note like N'%" + request.tim + "%')";
            if (request.loaixe != ""  && request.loaixe != null)
                str2 = " and idpart =N'" + request.loaixe + "'";
            if (request.ActionType != "" && request.ActionType != null)
                str1 = " and processtype= N'" + request.ActionType + "'";
            try
            {
                using (DB db = new DB(request.blockCode))
                {
                    string sql = "select  * from ticketlog where dateprocess between '" + request.fromDate.ToString("yyyy-MM-dd 00:00:00") + "' and '" + request.toDate.ToString("yyyy-MM-dd 23:59:59") + "' " + str3 + str2 + str1;
                    var kq = db.Database.SqlQuery<TicketLog>(sql).ToList();
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
