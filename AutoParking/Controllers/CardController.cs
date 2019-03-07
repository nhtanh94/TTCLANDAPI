using AutoParking.Models;
using AutoParking.Models.RequestModel;
using AutoParking.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoParking.Entities;
using AutoParking.Models.RepsponseModel;

namespace AutoParking.Controllers
{
    public class CardController : BaseController
    {
      /// <summary>
      /// LẤY DANH SÁCH THẺ XE
      /// </summary>
      /// <param name="blockCode">
      /// Code : Mã tòa nhà M1,M2
      /// </param>
      /// <returns></returns>
        [HttpGet]
        [Route("api/v1/list-card")]
        public HttpResponseMessage GetListCard(string blockCode)
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
                var model = new CardViewModel();
                return ResponseSuccess(model.GetResponseCard(blockCode));
            }
            catch
            {
                return ResponseFail(Constants.FAILD);
            }           
            
        }
        //Có thẻ chênh lệnh giữa thẻ vé tháng và thẻ vãng lai đã tạo vé tháng
        //do 1 số thẻ vé tháng tự gõ mã thẻ nên số thẻ vé tháng nhiều hơn số thẻ vé tháng đã tạo
        //hoặc do thẻ bị xóa đi 1 phần.
        /// <summary>
        /// DANH SÁCH THẺ CHƯA TẠO VÉ THÁNG
        /// </summary>
        /// <param name="blockCode">
        /// Code : Mã tòa nhà
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/list-card-create-ticketmonth")]
        public HttpResponseMessage GetListCardCreateTicketMonth(string blockCode)
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
                var model = new CardViewModel();
                return ResponseSuccess(model.GetResponseCardCreateTicketMonth(blockCode));
            }
            catch
            {
                return ResponseFail(Constants.FAILD);
            }

        }
        /// <summary>
        /// XÓA THẺ XE
        /// </summary>
        /// <param name="request">
        /// Code : Mã tòa nhà M1, M2
        /// ID : Mã Thẻ
        /// </param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/v1/delete-card")]
        public HttpResponseMessage DeleteCard([FromBody]RequestDeleteCard request)
        {
            if (IsBodyNull(request))
            {
                return ResponseFail(Constants.BODY_NOT_FOUND);
            }
            if (!CheckCode.checkcode(request.blockCode))
            {
                return ResponseFail(Constants.CODEERROR);
            }
            try
            {
                SmartCard card;
                using(DB db = new DB(request.blockCode))
                {
                    card = db.SmartCards.Find(request.ID);
                    db.SmartCards.Remove(card);
                    db.SaveChanges();
                }                                        
                 var model = new CardViewModel();
                 string info = "Xóa thẻ : " + request.ID + "\n   -STT : " + card.Identify + "\n   -Mã thẻ : " + request.ID + "\n   -Loại thẻ : " + model.GetPartName(card.ID,request.blockCode) + "\n   -Sử dụng : " + card.Using;
                    var logModel = new LogViewModel();
                    logModel.AddLog(ActionType.DELETE_CARD_INFO, DateTime.Now, info,request.blockCode);
                    return ResponseSuccess(Constants.SUCCESS,model.Statistical(request.blockCode));
                
               
            }
            catch
            {
                return ResponseSuccess(Constants.FAILD);
            }
        }
        /// <summary>
        /// THỐNG KÊ SỐ LƯỢNG THẺ TẤT CẢ CÁC BLOCK
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/list-card-report")]
        public HttpResponseMessage DeleteCard([FromBody]RequestCardReport requestCard)
        {
            try
            {
                CardViewModel cardViewModel = new CardViewModel();
                return ResponseSuccess(cardViewModel.GetCardReport(requestCard));
            }
            catch
            {
                return ResponseFail("ERROR");
            }
        }
    }
}
