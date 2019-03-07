using AutoParking.Entities;
using AutoParking.Models;
using AutoParking.Models.RequestModel;
using AutoParking.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AutoParking.Controllers
{
    public class CarController : BaseController
    {
        /// <summary>
        /// XEM LỊCH SỬ XE RA VÀO
        /// </summary>
        /// <param name="cars">
        /// Code :  Mã tòa nhà M1,M2, fromDate: Thời gian bắt đầ tiềm kiếm, toDate: Thời gian kết thúc tìm kiếm
        /// Không bắc buộc (idIn : Nhân viên vào, idOut: Nhân viên ra, Stt: STT thẻ, Bienso: Biển số xe )
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/search-car")]
        public HttpResponseMessage GetCars(RequestCars cars)
        {
            if (IsBodyNull(cars))
            {
                return ResponseFail(Constants.BODY_NOT_FOUND);
            }
            if (cars.fromDate > cars.toDate)
            {
                return ResponseFail(Constants.MSG_ERROR_DATE);
            }
            TimeSpan interval = cars.toDate.Subtract(cars.fromDate);
            if (interval.Days > 7)
            {
                return ResponseFail(Constants.MSG_ERROR_MAXIMUM_DATE_7);
            }
            if (!CheckCode.checkcode(cars.blockCode))
            {
                return ResponseFail(Constants.CODEERROR);
            }
            string digit = "";
            int stti = 0;
            int.TryParse(cars.Stt, out stti);
            if (stti != 0)
                digit = " and id in (select id from smartcard where identify = " + stti.ToString() + ")";
            if (cars.Bienso != null)
                digit += " and digit like N'%" + cars.Bienso + "%'";
            string sql = @"select  ROW_NUMBER() OVER(ORDER BY timestart DESC) AS stt,(select top 1 identify from SmartCard s where s.id = c.id) as STTThe, id,digit,part,(select top 1 name from part p where p.id = c.idpart) as LOAIXE,timestart,timeend,cost,idticketmonth,idin,idout,matthe,images,images2,images3,images4, account,dateupdate,
                        (select top (1) tenkh from ticketmonth t where t.id = c.id and processdate <=timestart order by rowid desc ) as Name,
                        (select top 1 company from ticketmonth t where t.id = c.id and processdate <=timestart order by rowid desc ) as Company, computer 
                        from car c where (timestart between '2000-11-11 11:11:11' and '2222-11-11 11:11:11' or timeend between '2000-11-11 11:11:11' and '2222-11-11 11:11:11')
                        and (1=1  and idin  = '1' and idout ='1') " + digit;
            if (!string.IsNullOrEmpty(cars.idIn) && !string.IsNullOrEmpty(cars.idOut))
            {
                sql = sql.Replace("2000-11-11 11:11:11", cars.fromDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("2222-11-11 11:11:11", cars.toDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("and idin  = '1'", "and idin =" + "'" + cars.idIn + "'").Replace("and idout ='1'", "and idout =" + "'" + cars.idOut + "'");
            }
            else
            {
                sql = sql.Replace("2000-11-11 11:11:11", cars.fromDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("2222-11-11 11:11:11", cars.toDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("and idin  = '1'", "").Replace("and idout ='1'", "");
            }
            try
            {
                List<CarContract> kq;
                using (DB db = new DB(cars.blockCode))
                {
                    kq = db.Database.SqlQuery<CarContract>(sql).ToList();

                }

                return ResponseSuccess(kq);


            }
            catch
            {
                return ResponseFail(Constants.FAILD);
            }
        }
        /// <summary>
        /// XEM LỊCH SỬ XE THÁNG RA VÀO
        /// </summary>
        /// <param name="cars">
        /// Code :  Mã tòa nhà M1,M2, fromDate: Thời gian bắt đầ tiềm kiếm, toDate: Thời gian kết thúc tìm kiếm
        /// Không bắc buộc (idIn : Nhân viên vào, idOut: Nhân viên ra, Stt: STT thẻ, Bienso: Biển số xe )
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/search-car-ticketmonth")]
        public HttpResponseMessage GetCarsTicketMonth(RequestCars cars)
        {
            if (IsBodyNull(cars))
            {
                return ResponseFail(Constants.BODY_NOT_FOUND);
            }
            if (cars.fromDate > cars.toDate)
            {
                return ResponseFail(Constants.MSG_ERROR_DATE);
            }
            TimeSpan interval = cars.toDate.Subtract(cars.fromDate);
            if (interval.Days > 7)
            {
                return ResponseFail(Constants.MSG_ERROR_MAXIMUM_DATE_7);
            }
            if (!CheckCode.checkcode(cars.blockCode))
            {
                return ResponseFail(Constants.CODEERROR);
            }

            string digit = "";
            int stti = 0;
            int.TryParse(cars.Stt, out stti);
            if (stti != 0)
                digit = " and id in (select id from smartcard where identify = " + stti.ToString() + ")";
            if (cars.Bienso != null)
                digit += " and digit like N'%" + cars.Bienso + "%'";
            string sql = @"select  ROW_NUMBER() OVER(ORDER BY timestart DESC) AS stt,(select top 1 identify from SmartCard s where s.id = c.id) as STTThe, id,digit,part,(select top 1 name from part p where p.id = c.idpart) as LOAIXE,timestart,timeend,cost,idticketmonth,idin,idout,matthe,images,images2,images3,images4, account,dateupdate,
                        (select top (1) tenkh from ticketmonth t where t.id = c.id and processdate <=timestart order by rowid desc ) as Name,
                        (select top 1 company from ticketmonth t where t.id = c.id and processdate <=timestart order by rowid desc ) as Company, computer 
                        from car c where idticketmonth != '' and (timestart between '2000-11-11 11:11:11' and '2222-11-11 11:11:11' or timeend between '2000-11-11 11:11:11' and '2222-11-11 11:11:11')
                        and (1=1  and idin  = '1' and idout ='1') " + digit;
            if (!string.IsNullOrEmpty(cars.idIn) && !string.IsNullOrEmpty(cars.idOut))
            {
                sql = sql.Replace("2000-11-11 11:11:11", cars.fromDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("2222-11-11 11:11:11", cars.toDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("and idin  = '1'", "and idin =" + "'" + cars.idIn + "'").Replace("and idout ='1'", "and idout =" + "'" + cars.idOut + "'");
            }
            else
            {
                sql = sql.Replace("2000-11-11 11:11:11", cars.fromDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("2222-11-11 11:11:11", cars.toDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("and idin  = '1'", "").Replace("and idout ='1'", "");
            }

            try
            {
                List<CarContract> kq;
                using (DB db = new DB(cars.blockCode))
                {
                    kq = db.Database.SqlQuery<CarContract>(sql).ToList();

                }
                return ResponseSuccess(kq);

            }
            catch
            {
                return ResponseFail(Constants.FAILD);
            }

        }


        /// <summary>
        /// XEM DOANH THU XE VÃNG LAI
        /// </summary>
        /// <param name="request">
        /// Code : Mã tòa nhà M1,M2
        /// fromDate: Thời gian bắt đầ tiềm kiếm, toDate: Thời gian kết thúc tìm kiếm
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/revenue")]
        public HttpResponseMessage GetRevenue([FromBody]RequestTicketMonthReport request)
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
            string sql = @"select * from (
                                select id,'     '+name as name, 
                                (select  convert(varchar,count(id)) from car c where c.idpart = a.id and (c.idticketmonth ='' or c.idticketmonth is null)  and timestart >= '2013-11-11 00:00:00' and timestart <'2013-11-12 00:00:00'  and (1=1  and idin ='1') )as xevao,
                                (select  convert(varchar,count(id)) from car c where c.idpart = a.id and (c.idticketmonth ='' or c.idticketmonth is null)  and timeend >= '2013-11-11 00:00:00' and timeend <'2013-11-12 00:00:00'  and (1=1  and idout ='1'))as xera,
                                (select  convert(varchar,count(id)) from car c where c.idpart = a.id and (c.idticketmonth ='' or c.idticketmonth is null)  and timestart <'2013-11-12 00:00:00'  and (timeend > '2013-11-12 00:00:00' or TimeEnd is null) and (1=1  and idout ='1'))as xeton,
                                (select  convert(varchar,count(id)) from car c where c.idpart = a.id and (c.idticketmonth ='' or c.idticketmonth is null)  and dateupdate >= '2013-11-11 00:00:00' and dateupdate <'2013-11-12 00:00:00'   and matthe <>0 and (1=1  and idout ='1'))as xemt,
                                (select  convert(varchar,isnull(sum(cost),0)) from car c where c.idpart = a.id and (c.idticketmonth ='' or c.idticketmonth is null)  and timeend >= '2013-11-11 00:00:00' and timeend <'2013-11-12 00:00:00' and (1=1  and idout ='1') )as tien,
                                (select  convert(varchar,isnull(sum(matthe),0)) from car c where c.idpart = a.id and (c.idticketmonth ='' or c.idticketmonth is null)  and dateupdate >= '2013-11-11 00:00:00' and dateupdate <'2013-11-12 00:00:00'   and matthe <>0 and (1=1  and idout ='1'))as tienmt
                                 from (select distinct idpart as id,(select top 1 name from part where id = idpart) as name from car where idticketmonth = '')  a
                                union 
                                 (select '-1' as id,N'    ___Tổng xe thường' as name,
                                    (select convert(varchar,count(id)) from car c where (c.idticketmonth ='' or c.idticketmonth is null)  and timestart >= '2013-11-11 00:00:00' and timestart <'2013-11-12 00:00:00'  and (1=1  and idin ='1'))as xevao,
                                    (select convert(varchar,count(id)) from car c where (c.idticketmonth ='' or c.idticketmonth is null)  and timeend >= '2013-11-11 00:00:00' and timeend <'2013-11-12 00:00:00'  and (1=1  and idout ='1'))as xera,
                                    (select convert(varchar,count(id)) from car c where (c.idticketmonth ='' or c.idticketmonth is null)  and timestart <'2013-11-12 00:00:00' and (timeend > '2013-11-12 00:00:00' or TimeEnd is null) and (1=1  and idout ='1'))as xeton,
			                        (select convert(varchar,count(id)) from car c where (c.idticketmonth ='' or c.idticketmonth is null)  and dateupdate >= '2013-11-11 00:00:00' and dateupdate <'2013-11-12 00:00:00'   and matthe <>0 and (1=1  and idout ='1'))as xemt,
                                    (select convert(varchar,isnull(sum(cost),0)) from car c where  (c.idticketmonth ='' or c.idticketmonth is null)  and timeend >= '2013-11-11 00:00:00' and timeend <'2013-11-12 00:00:00'  and (1=1  and idout ='1'))as tien,
                                    (select convert(varchar,isnull(sum(matthe),0)) from car c where  (c.idticketmonth ='' or c.idticketmonth is null)  and dateupdate >= '2013-11-11 00:00:00' and dateupdate <'2013-11-12 00:00:00'    and matthe <>0 and (1=1  and idout ='1'))as tienmt
                                    )
                                union
                                select id,'   '+name as name, 
                                (select convert(varchar,count(id)) from car c where c.idpart = a.id and c.idticketmonth <>'' and timestart >= '2013-11-11 00:00:00' and timestart <'2013-11-12 00:00:00'  and (1=1  and idin ='1'))as xevao,
                                (select convert(varchar,count(id)) from car c where c.idpart = a.id and c.idticketmonth <>'' and timeend >= '2013-11-11 00:00:00' and timeend <'2013-11-12 00:00:00'  and (1=1  and idout ='1'))as xera,
                                (select convert(varchar,count(id)) from car c where c.idpart = a.id and c.idticketmonth <>'' and timestart <'2013-11-12 00:00:00'   and (timeend > '2013-11-12 00:00:00' or TimeEnd is null and (1=1  and idout ='1')) )as xeton,
                                (select convert(varchar,count(id)) from car c where c.idpart = a.id and c.idticketmonth <>'' and dateupdate >= '2013-11-11 00:00:00' and dateupdate <'2013-11-12 00:00:00'    and matthe <>0 and (1=1  and idout ='1'))as xemt,
                                (select convert(varchar,isnull(sum(cost),0)) from car c where c.idpart = a.id and c.idticketmonth <>'' and timeend >= '2013-11-11 00:00:00' and timeend <'2013-11-12 00:00:00'  and (1=1  and idout ='1'))as tien,
                                (select convert(varchar,isnull(sum(matthe),0)) from car c where c.idpart = a.id and c.idticketmonth <>'' and dateupdate >= '2013-11-11 00:00:00' and dateupdate <'2013-11-12 00:00:00'    and matthe <>0 and (1=1  and idout ='1'))as tienmt
                                 from (select distinct idpart as id,'Tháng: '+ (select top 1 name from part where id = idpart) as name from car where idticketmonth <>'') a
                                union 
                                 (select '-2' as id,N'  ____Tổng xe tháng' as name,
                                    (select convert(varchar,count(id)) from car c where c.idticketmonth <>'' and timestart >= '2013-11-11 00:00:00' and timestart <'2013-11-12 00:00:00'  and (1=1  and idin ='1'))as xevao,
                                    (select convert(varchar,count(id)) from car c where c.idticketmonth <>'' and timeend >= '2013-11-11 00:00:00' and timeend <'2013-11-12 00:00:00'  and (1=1  and idout ='1'))as xera,
                                    (select convert(varchar,count(id)) from car c where c.idticketmonth <>'' and timestart <'2013-11-12 00:00:00'  and (timeend > '2013-11-12 00:00:00' or TimeEnd is null) and (1=1  and idout ='1'))as xeton,
                                    (select convert(varchar,count(id)) from car c where c.idticketmonth <>'' and dateupdate >= '2013-11-11 00:00:00' and dateupdate <'2013-11-12 00:00:00'   and matthe <>0 and (1=1  and idout ='1'))as xemt,
                                    (select convert(varchar,isnull(sum(cost),0)) from car c where  c.idticketmonth <>'' and timeend >= '2013-11-11 00:00:00' and timeend <'2013-11-12 00:00:00'  and (1=1  and idout ='1'))as tien,
                                    (select convert(varchar,isnull(sum(matthe),0)) from car c where  c.idticketmonth <>'' and dateupdate >= '2013-11-11 00:00:00' and dateupdate <'2013-11-12 00:00:00'   and matthe <>0 and (1=1  and idout ='1'))as tienmt
                                    )
                                union 
                                 (select '-3' as id,N'______Tổng cộng' as name,
                                    (select convert(varchar,count(id)) from car c where timestart >= '2013-11-11 00:00:00' and timestart <'2013-11-12 00:00:00'  and (1=1  and idin ='1'))as xevao,
                                    (select convert(varchar,count(id)) from car c where timeend >= '2013-11-11 00:00:00' and timeend <'2013-11-12 00:00:00'  and (1=1  and idout ='1'))as xera,
                                    (select convert(varchar,count(id)) from car c where timestart <'2013-11-12 00:00:00'  and (timeend > '2013-11-12 00:00:00' or TimeEnd is null) and (1=1  and idout ='1'))as xeton,
                                    (select convert(varchar,count(id)) from car c where dateupdate >= '2013-11-11 00:00:00' and dateupdate <'2013-11-12 00:00:00'   and matthe <>0 and (1=1  and idout ='1'))as xemt,
                                    (select convert(varchar,isnull(sum(cost),0)) from car c where timeend >= '2013-11-11 00:00:00' and timeend <'2013-11-12 00:00:00'  and (1=1  and idout ='1'))as tien,
                                    (select convert(varchar,isnull(sum(matthe),0)) from car c where dateupdate >= '2013-11-11 00:00:00' and dateupdate <'2013-11-12 00:00:00'   and matthe <>0 and (1=1  and idout ='1'))as tienmt
                                    )
                        ) a order by name asc";
            sql = sql.Replace("2013-11-11 00:00:00", request.fromDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("2013-11-12 00:00:00", request.toDate.ToString("yyyy-MM-dd HH:mm:ss")).Replace("and idin ='1'", "").Replace("and idout ='1'", "");
            try
            {
                List<Revenue> kq;
                using (DB db = new DB(request.blockCode))
                {
                    kq = db.Database.SqlQuery<Revenue>(sql).ToList();

                }

                return ResponseSuccess(kq);

            }
            catch
            {
                return ResponseFail(Constants.FAILD);
            }
        }
        /// <summary>
        /// LẤY DANH SÁC XE TỒN
        /// </summary>
        /// <param name="blockCode">
        /// Code: Mã tòa nhà M1,M2
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/search-car-inventory")]
        public HttpResponseMessage GetCarsInventory(string blockCode)
        {

            string sql = @"select  ROW_NUMBER() OVER(ORDER BY timestart DESC) AS stt,(select top 1 identify from SmartCard s where s.id = c.id) as STTThe, id,digit,part,(select top 1 name from part p where p.id = c.idpart) as LOAIXE,timestart,timeend,cost,idticketmonth,idin,idout,matthe,images,images2,images3,images4, account,dateupdate,
                        (select top (1) tenkh from ticketmonth t where t.id = c.id and processdate <=timestart order by rowid desc ) as Name,
                        (select top 1 company from ticketmonth t where t.id = c.id and processdate <=timestart order by rowid desc ) as Company, computer 
                        from car c where TimeEnd IS NULL";
            if (!CheckCode.checkcode(blockCode))
            {
                return ResponseFail(Constants.CODEERROR);
            }
            try
            {
                List<CarContract> kq;
                using (DB db = new DB(blockCode))
                {
                    kq = db.Database.SqlQuery<CarContract>(sql).ToList();
                }
                return ResponseSuccess(kq);
            }
            catch
            {

                return ResponseFail(Constants.FAILD);
            }

        }
    }
}