using AutoParking.Controllers;
using AutoParking.Entities;
using AutoParking.Models.RepsponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models
{
    public class TicketMonthViewModel : BaseController
    {
        public int GetMaxTicketMonthId(string blockCode)
        {
            using(DB db = new DB(blockCode))
            {
                return db.TicketMonths.Max(x => x.RowID);
            }

        }

        public TicketMonth GetTicketMonth(int id, string blockCode)
        {
            using(DB db = new DB(blockCode))
            {
                return db.TicketMonths.SingleOrDefault(x => x.RowID == id);
            }
           


        }
        //Đã cập nhật lại blockCode
        public object ListTicketMonth()
        {
            List<object> listAllTicketMonth = new List<object>();
            try
            {
                IEnumerable<object> listTicketMonthM1;
                IEnumerable<object> listTicketMonthM2;
                using (DB db = new DB("M1"))
                {
                     listTicketMonthM1 =( from TicketMonths in db.TicketMonths
                                          where
                                                (from t in (
                                                  (from TicketMonths0 in db.TicketMonths
                                                   group TicketMonths0 by new
                                                   {
                                                       TicketMonths0.ID
                                                   } into g
                                                   select new
                                                   {
                                                       stt = (int?)g.Max(p => p.RowID),
                                                       g.Key.ID
                                                   }))
                                                 select new
                                                 {
                                                     t.stt
                                                 }).Contains(new { stt = (Int32?)TicketMonths.RowID }) &&
                                            (TicketMonths.Status < 2)
                                          select new
                                          {
                                              RowID = TicketMonths.RowID,
                                              Stt = TicketMonths.Stt,
                                              TicketMonths.ID,
                                              ProcessDate = TicketMonths.ProcessDate,
                                              Digit = (TicketMonths.Digit.Replace("-", "")).Replace(".", "").ToUpper(),
                                              TenKH = TicketMonths.TenKH,
                                              TicketMonths.CMND,
                                              Company = TicketMonths.Company,
                                              Email = TicketMonths.Email,
                                              Address = TicketMonths.Address,
                                              CarKind = TicketMonths.CarKind,
                                              IDPart = TicketMonths.IDPart,
                                              DateStart = TicketMonths.DateStart,
                                              DateEnd = TicketMonths.DateEnd,
                                              Note = TicketMonths.Note,
                                              Amount = TicketMonths.Amount,
                                              ChargesAmount = TicketMonths.ChargesAmount,
                                              Status = TicketMonths.Status,
                                              Account = TicketMonths.Account,
                                              Images = TicketMonths.Images,
                                              DayUnLimit = TicketMonths.DayUnLimit,
                                              Name = ((from Parts in db.Parts
                                                       where
                                                        Parts.ID == TicketMonths.IDPart
                                                       select new
                                                       {
                                                           Parts.Name
                                                       }).Take(1).FirstOrDefault().Name),
                                              blockCode = "M1"

                                          }).ToList();
                    
                }
                using (DB db = new DB("M2"))
                {
                    listTicketMonthM2 = (from TicketMonths in db.TicketMonths
                                         where
                                               (from t in (
                                                 (from TicketMonths0 in db.TicketMonths
                                                  group TicketMonths0 by new
                                                  {
                                                      TicketMonths0.ID
                                                  } into g
                                                  select new
                                                  {
                                                      stt = (int?)g.Max(p => p.RowID),
                                                      g.Key.ID
                                                  }))
                                                select new
                                                {
                                                    t.stt
                                                }).Contains(new { stt = (Int32?)TicketMonths.RowID }) &&
                                           (TicketMonths.Status < 2)
                                         select new
                                         {
                                             RowID = TicketMonths.RowID,
                                             Stt = TicketMonths.Stt,
                                             TicketMonths.ID,
                                             ProcessDate = TicketMonths.ProcessDate,
                                             Digit = (TicketMonths.Digit.Replace("-", "")).Replace(".", "").ToUpper(),
                                             TenKH = TicketMonths.TenKH,
                                             TicketMonths.CMND,
                                             Company = TicketMonths.Company,
                                             Email = TicketMonths.Email,
                                             Address = TicketMonths.Address,
                                             CarKind = TicketMonths.CarKind,
                                             IDPart = TicketMonths.IDPart,
                                             DateStart = TicketMonths.DateStart,
                                             DateEnd = TicketMonths.DateEnd,
                                             Note = TicketMonths.Note,
                                             Amount = TicketMonths.Amount,
                                             ChargesAmount = TicketMonths.ChargesAmount,
                                             Status = TicketMonths.Status,
                                             Account = TicketMonths.Account,
                                             Images = TicketMonths.Images,
                                             DayUnLimit = TicketMonths.DayUnLimit,
                                             Name = ((from Parts in db.Parts
                                                      where
                                                       Parts.ID == TicketMonths.IDPart
                                                      select new
                                                      {
                                                          Parts.Name
                                                      }).Take(1).FirstOrDefault().Name),
                                             blockCode = "M2"

                                         }).ToList();

                }
                listAllTicketMonth.AddRange(listTicketMonthM1.ToList());
                listAllTicketMonth.AddRange(listTicketMonthM2.ToList());
                return listAllTicketMonth;
            }

            catch
            {
                return null;
            }



        }
        //Đã cập nhật lại blockCode
        public object ListBlackTicketMonth()
        {
            List<object> listAllBlackTicketMonth = new List<object>();
            try
            {
                IEnumerable<object> listTicketBlackM1;
                IEnumerable<object> listTicketBlackM2;
                using (DB db = new DB("M1"))
                {
                    listTicketBlackM1 = (from TicketMonths in db.TicketMonths
                                       where
                                             (from t in (
                                               (from TicketMonths0 in db.TicketMonths
                                                group TicketMonths0 by new
                                                {
                                                    TicketMonths0.ID
                                                } into g
                                                select new
                                                {
                                                    stt = (int?)g.Max(p => p.RowID),
                                                    g.Key.ID
                                                }))
                                              select new
                                              {
                                                  t.stt
                                              }).Contains(new { stt = (Int32?)TicketMonths.RowID }) &&
                                         (TicketMonths.Status == 4)
                                       select new
                                       {
                                           RowID = TicketMonths.RowID,
                                           Stt = TicketMonths.Stt,
                                           TicketMonths.ID,
                                           ProcessDate = TicketMonths.ProcessDate,
                                           Digit = (TicketMonths.Digit.Replace("-","")).Replace(".","").ToUpper(),
                                           TenKH = TicketMonths.TenKH,
                                           TicketMonths.CMND,
                                           Company = TicketMonths.Company,
                                           Email = TicketMonths.Email,
                                           Address = TicketMonths.Address,
                                           CarKind = TicketMonths.CarKind,
                                           IDPart = TicketMonths.IDPart,
                                           DateStart = TicketMonths.DateStart,
                                           DateEnd = TicketMonths.DateEnd,
                                           Note = TicketMonths.Note,
                                           Amount = TicketMonths.Amount,
                                           ChargesAmount = TicketMonths.ChargesAmount,
                                           Status = TicketMonths.Status,
                                           Account = TicketMonths.Account,
                                           Images = TicketMonths.Images,
                                           DayUnLimit = TicketMonths.DayUnLimit,
                                           Name = ((from Parts in db.Parts
                                                    where
                                                     Parts.ID == TicketMonths.IDPart
                                                    select new
                                                    {
                                                        Parts.Name
                                                    }).Take(1).FirstOrDefault().Name),
                                            blockCode="M1"
                                       }).ToList();

                }
                using (DB db = new DB("M2"))
                {
                    listTicketBlackM2 = (from TicketMonths in db.TicketMonths
                                         where
                                               (from t in (
                                                 (from TicketMonths0 in db.TicketMonths
                                                  group TicketMonths0 by new
                                                  {
                                                      TicketMonths0.ID
                                                  } into g
                                                  select new
                                                  {
                                                      stt = (int?)g.Max(p => p.RowID),
                                                      g.Key.ID
                                                  }))
                                                select new
                                                {
                                                    t.stt
                                                }).Contains(new { stt = (Int32?)TicketMonths.RowID }) &&
                                           (TicketMonths.Status == 4)
                                         select new
                                         {
                                             RowID = TicketMonths.RowID,
                                             Stt = TicketMonths.Stt,
                                             TicketMonths.ID,
                                             ProcessDate = TicketMonths.ProcessDate,
                                             Digit = (TicketMonths.Digit.Replace("-", "")).Replace(".", "").ToUpper(),
                                             TenKH = TicketMonths.TenKH,
                                             TicketMonths.CMND,
                                             Company = TicketMonths.Company,
                                             Email = TicketMonths.Email,
                                             Address = TicketMonths.Address,
                                             CarKind = TicketMonths.CarKind,
                                             IDPart = TicketMonths.IDPart,
                                             DateStart = TicketMonths.DateStart,
                                             DateEnd = TicketMonths.DateEnd,
                                             Note = TicketMonths.Note,
                                             Amount = TicketMonths.Amount,
                                             ChargesAmount = TicketMonths.ChargesAmount,
                                             Status = TicketMonths.Status,
                                             Account = TicketMonths.Account,
                                             Images = TicketMonths.Images,
                                             DayUnLimit = TicketMonths.DayUnLimit,
                                             Name = ((from Parts in db.Parts
                                                      where
                                                       Parts.ID == TicketMonths.IDPart
                                                      select new
                                                      {
                                                          Parts.Name
                                                      }).Take(1).FirstOrDefault().Name),
                                             blockCode = "M2"
                                         }).ToList();

                }
                listAllBlackTicketMonth.AddRange(listTicketBlackM1.ToList());
                listAllBlackTicketMonth.AddRange(listTicketBlackM2.ToList());
                return listAllBlackTicketMonth;
            }

            catch
            {
                return null;
            }



        }

        public object GetTicketMonthID(string blockCode,int rowid)
        {
            try
            {
                object listTicketMonth;
                using (DB db = new DB(blockCode))
                {
                    listTicketMonth = (from TicketMonths in db.TicketMonths
                                       where
                                            TicketMonths.RowID == rowid
                                       select new
                                       {
                                           RowID = TicketMonths.RowID,
                                           Stt = TicketMonths.Stt,
                                           TicketMonths.ID,
                                           ProcessDate = TicketMonths.ProcessDate,
                                           Digit = (TicketMonths.Digit.Replace("-", "")).Replace(".", "").ToUpper(),
                                           TenKH = TicketMonths.TenKH,
                                           TicketMonths.CMND,
                                           Company = TicketMonths.Company,
                                           Email = TicketMonths.Email,
                                           Address = TicketMonths.Address,
                                           CarKind = TicketMonths.CarKind,
                                           IDPart = TicketMonths.IDPart,
                                           DateStart = TicketMonths.DateStart,
                                           DateEnd = TicketMonths.DateEnd,
                                           Note = TicketMonths.Note,
                                           Amount = TicketMonths.Amount,
                                           ChargesAmount = TicketMonths.ChargesAmount,
                                           Status = TicketMonths.Status,
                                           Account = TicketMonths.Account,
                                           Images = TicketMonths.Images,
                                           DayUnLimit = TicketMonths.DayUnLimit,
                                           Name =
                                             ((from Parts in db.Parts
                                               where
        Parts.ID == TicketMonths.IDPart
                                               select new
                                               {
                                                   Parts.Name
                                               }).Take(1).FirstOrDefault().Name),
                                           blockCode = blockCode
                                       }).ToList();

                }
                return listTicketMonth;
            }

            catch
            {
                return null;
            }



        }
        //Đã cập nhật lại blockCode
        public object ListTicketMonthBlock()
        {
            List<object> listAllBlockTicketMonth = new List<object>();
            try
            {
                IEnumerable<object> listTicketBlockM1;
                IEnumerable<object> listTicketBlockM2;
                using (DB db = new DB("M1"))
                {
                    listTicketBlockM1 = (from TicketMonths in db.TicketMonths
                                         where
                                               (from t in (
                                                 (from TicketMonths0 in db.TicketMonths
                                                  group TicketMonths0 by new
                                                  {
                                                      TicketMonths0.ID
                                                  } into g
                                                  select new
                                                  {
                                                      stt = (int?)g.Max(p => p.RowID),
                                                      g.Key.ID
                                                  }))
                                                select new
                                                {
                                                    t.stt
                                                }).Contains(new { stt = (Int32?)TicketMonths.RowID }) &&
                                           (TicketMonths.Status == 3)
                                         select new
                                         {
                                             RowID = TicketMonths.RowID,
                                             Stt = TicketMonths.Stt,
                                             TicketMonths.ID,
                                             ProcessDate = TicketMonths.ProcessDate,
                                             Digit = (TicketMonths.Digit.Replace("-", "")).Replace(".", "").ToUpper(),
                                             TenKH = TicketMonths.TenKH,
                                             TicketMonths.CMND,
                                             Company = TicketMonths.Company,
                                             Email = TicketMonths.Email,
                                             Address = TicketMonths.Address,
                                             CarKind = TicketMonths.CarKind,
                                             IDPart = TicketMonths.IDPart,
                                             DateStart = TicketMonths.DateStart,
                                             DateEnd = TicketMonths.DateEnd,
                                             Note = TicketMonths.Note,
                                             Amount = TicketMonths.Amount,
                                             ChargesAmount = TicketMonths.ChargesAmount,
                                             Status = TicketMonths.Status,
                                             Account = TicketMonths.Account,
                                             Images = TicketMonths.Images,
                                             DayUnLimit = TicketMonths.DayUnLimit,
                                             Name =
                                             ((from Parts in db.Parts
                                               where
        Parts.ID == TicketMonths.IDPart
                                               select new
                                               {
                                                   Parts.Name
                                               }).Take(1).FirstOrDefault().Name),
                                             blockCode = "M1"
                                         }).ToList();

                }
                using (DB db = new DB("M2"))
                {
                    listTicketBlockM2 = (from TicketMonths in db.TicketMonths
                                         where
                                               (from t in (
                                                 (from TicketMonths0 in db.TicketMonths
                                                  group TicketMonths0 by new
                                                  {
                                                      TicketMonths0.ID
                                                  } into g
                                                  select new
                                                  {
                                                      stt = (int?)g.Max(p => p.RowID),
                                                      g.Key.ID
                                                  }))
                                                select new
                                                {
                                                    t.stt
                                                }).Contains(new { stt = (Int32?)TicketMonths.RowID }) &&
                                           (TicketMonths.Status == 3)
                                         select new
                                         {
                                             RowID = TicketMonths.RowID,
                                             Stt = TicketMonths.Stt,
                                             TicketMonths.ID,
                                             ProcessDate = TicketMonths.ProcessDate,
                                             Digit = (TicketMonths.Digit.Replace("-", "")).Replace(".", "").ToUpper(),
                                             TenKH = TicketMonths.TenKH,
                                             TicketMonths.CMND,
                                             Company = TicketMonths.Company,
                                             Email = TicketMonths.Email,
                                             Address = TicketMonths.Address,
                                             CarKind = TicketMonths.CarKind,
                                             IDPart = TicketMonths.IDPart,
                                             DateStart = TicketMonths.DateStart,
                                             DateEnd = TicketMonths.DateEnd,
                                             Note = TicketMonths.Note,
                                             Amount = TicketMonths.Amount,
                                             ChargesAmount = TicketMonths.ChargesAmount,
                                             Status = TicketMonths.Status,
                                             Account = TicketMonths.Account,
                                             Images = TicketMonths.Images,
                                             DayUnLimit = TicketMonths.DayUnLimit,
                                             Name =
                                             ((from Parts in db.Parts
                                               where
        Parts.ID == TicketMonths.IDPart
                                               select new
                                               {
                                                   Parts.Name
                                               }).Take(1).FirstOrDefault().Name),
                                             blockCode = "M2"
                                         }).ToList();
                }

                listAllBlockTicketMonth.AddRange(listTicketBlockM1.ToList());
                listAllBlockTicketMonth.AddRange(listTicketBlockM2.ToList());
                return listAllBlockTicketMonth;
            }
            catch
            {
                return null;
            }
          


        }

        public object TicketMonthReport(string blockCode, DateTime fromDate,DateTime toDate)
        {
            string sql1 = string.Format("select COUNT(RowID) as Quantity, SUM(convert(int,amount)) as Price from TicketMonth t where  t.processdate between '{0}' and '{1}' and amount >0 and status in (0,1,3)", fromDate.ToString("yyyy-MM-dd HH:mm:ss"), toDate.ToString("yyyy-MM-dd HH:mm:ss"));
            string sql2 = string.Format("select *,ROW_NUMBER() OVER(ORDER BY COMPANY, t.dateStart) AS Row,  (select name from part p where p.id = t.idpart) as Name from ticketmonth t where  t.processdate between '{0}' and '{1}' and amount >0 and status in (0,1,3)", fromDate.ToString("yyyy-MM-dd HH:mm:ss"),toDate.ToString("yyyy-MM-dd HH:mm:ss"));
          
            ResponseTicketMonthReport doanhThuVT;
            using(DB db = new DB(blockCode))
            {
                try
                {
                    doanhThuVT = new ResponseTicketMonthReport();
                    doanhThuVT.TicketMonths = new List<TicketMonthResult>();
                    var query1 = db.Database.SqlQuery<ResponseTicketMonthReport>(sql1);
                    foreach (ResponseTicketMonthReport t in query1)
                    {
                        doanhThuVT.Price = t.Price;
                        doanhThuVT.Quantity = t.Quantity;
                    }
                    var query2 = db.Database.SqlQuery<TicketMonthResult>(sql2).ToList();
                    doanhThuVT.TicketMonths.AddRange(query2);
                    return doanhThuVT;
                }
                catch
                {
                    return null;
                }
            }
          
        }
        public List<TicketMonthsExpires> SearchTicketMonthExpires(string blockCode, string Sreach)
        {
            

            using (DB db = new DB(blockCode))
            {
                if (string.IsNullOrEmpty(Sreach))
                {

                    string sql = @"select * from (
	                            select rowid,stt,id,digit,tenkh,cmnd,company,email,images,address,amount,chargesamount,note, 
	                            case when datediff(day,getdate(),dateend) >=0 then N'Còn hạn' else N'Hết hạn' end as status, 
	                            abs(datediff(day,getdate(),dateend)) as songay,datestart,dateend ,account 
	                            from (select *   from ticketmonth where rowid in( select stt from (
		                            select max(rowid) as stt,id from ticketmonth  group by id) t) and status in(0,1)) tc)
                            t order by status desc,songay ";

                    var kq = db.Database.SqlQuery<TicketMonthsExpires>(sql).ToList();
                    return kq;
                }
                else
                {
                    int stt = -1;

                    string searchcondition = "";

                    if (int.TryParse(Sreach, out stt))
                        searchcondition = " and (digit like N'%" + Sreach + "%' or tenkh like N'%" + Sreach + "%' or address like N'%" + Sreach + "%'  or company like N'%" + Sreach + "%' or stt = " + Sreach + " or id ='" + Sreach + "')";
                    else
                        searchcondition = " and (digit like N'%" + Sreach + "%' or tenkh like N'%" + Sreach + "%' or address like N'%" + Sreach + "%'  or company like N'%" + Sreach + "%' or id ='" + Sreach + "')";


                    string sql = @"select * from (
	                            select rowid,stt,id,digit,tenkh,cmnd,company,email,images,address,amount,chargesamount,note, 
	                            case when datediff(day,getdate(),dateend) >=0 then N'Còn hạn' else N'Hết hạn' end as status, 
	                            abs(datediff(day,getdate(),dateend)) as songay,datestart,dateend ,account 
	                            from (select *   from ticketmonth where rowid in( select stt from (
		                            select max(rowid) as stt,id from ticketmonth  group by id) t) and status in(0,1) " + @" " + searchcondition + @" ) tc)
                            t order by status desc,songay ";
                    try
                    {
                        var kq = db.Database.SqlQuery<TicketMonthsExpires>(sql).ToList();
                        return kq;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }



        }
    }
}