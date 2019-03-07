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
    public class LogController : BaseController
    {

        /// <summary>
        /// XEM LỊCH SỬ
        /// </summary>
        /// <param name="request">
        /// Code: Mã tòa nhà M1,M2
        /// fromDate:Tgian BĐ
        /// toDate:Tgian KT
        ///ActionType = Tất cả, Kích hoạt thẻ, Lưu mất thẻ, Tạo thẻ mới, Xóa thông tin thẻ, Ngưng sử dụng, Xóa thẻ tháng, Chỉnh sửa vé tháng, Kích hoạt lại thẻ tháng
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/list-log")]
        public HttpResponseMessage GetListLog([FromBody] LogRequest request)
        {
            if (IsBodyNull(request))
            {
                return ResponseFail(Constants.BODY_NOT_FOUND);
            }
            if (!CheckCode.checkcode(request.blockCode))
            {
                return ResponseFail(Constants.CODEERROR);
            }
            if (request.fromDate > request.toDate)
            {
                return ResponseFail(Constants.MSG_ERROR_DATE);
            }
            else
            {

                try
                {
                    var listLog = new List<Log>();
                    using (DB db = new DB(request.blockCode))
                    {
                        if (string.IsNullOrEmpty(request.ActionType))
                        {
                            listLog = db.Logs.AsEnumerable().Where(x => x.NgayXuly >= request.fromDate && x.NgayXuly <= request.toDate).OrderByDescending(x => x.NgayXuly).ToList();
                            return ResponseSuccess(listLog);
                        }
                        else if (request.ActionType == ActionType.ALL)
                        {
                            listLog = db.Logs.AsEnumerable().Where(x => x.NgayXuly >= request.fromDate && x.NgayXuly <= request.toDate).OrderByDescending(x => x.NgayXuly).ToList();
                            return ResponseSuccess(listLog);
                        }
                        listLog = db.Logs.AsEnumerable().Where(x => x.NgayXuly >= request.fromDate && x.NgayXuly <= request.toDate && x.LoaiThaoTac.Trim().Equals(request.ActionType)).OrderByDescending(x => x.NgayXuly).ToList();
                        return ResponseSuccess(listLog);
                    }


                }
                catch
                {
                    return ResponseFail(Constants.FAILD);
                }

            }



        }



    }

}
