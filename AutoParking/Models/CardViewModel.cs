using AutoParking.Controllers;
using AutoParking.Entities;
using AutoParking.Models.RepsponseModel;
using AutoParking.Models.RequestModel;
using AutoParking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoParking.Models
{
    public class CardViewModel : BaseController
    {
        public bool CheckIsTicketMonth(string ID, string code)
        {
            List<TicketMonth> result;
           using (DB db = new DB(code))
            {
              result = db.TicketMonths.AsEnumerable().Where(x => x.ID.Equals(ID) && x.Status < 2).ToList();
            }
            return result.Count > 0;


        }

        public string GetPartName(string ID, string code)
        {
            Part part;
            using(DB db = new DB(code))
            {
                part = db.Parts.Find(ID);
            }                   
            return part == null ? "" : part.Name;

        }
        // Đã fix
        public ResponseCard GetResponseCard(string code)
        {
            ResponseCard responseCard;
            List<ResponeCardCreateTicketMonth> listCard;
            using (DB db = new DB(code))
            {
                string sql = "select s.Identify, s.ID, case s.Using when 1 then N'Đang sử dụng' else N'Đã khóa' end as Using, p.Name, case ISNULL(t.ID, 'NULL') when 'NULL' then N'Chưa tạo' else N'Đã tạo' end as TicketMonth, (select top 1 amount from part where id = type) as Amount from SmartCard s left join (select t.ID from TicketMonth t, (select ID, MAX(RowID) as 'RowID' from TicketMonth group by ID) tt where t.RowID = tt.RowID and t.Status in (0,1,3)) t on s.ID = t.ID, Part p where s.Type = p.ID  order by s.Identify";
                listCard = db.Database.SqlQuery<ResponeCardCreateTicketMonth>(sql).ToList();

                string sqlString = @"select * from (
                            (select count(identify) as total, (select top 1 name from part where id = type) as typename, type, (case using when 'True' then N'Dùng' else N'Không dùng' end) as isusing,using from smartcard group by [type], using )
                union
                (select count(identify) as total, N'Tổng thẻ đang dùng' as typename, -1 as type, N'Dùng' as isusing, 1 as using from smartcard where using = 1)
                union
                (select count(identify) as total, N'Tổng thẻ không dùng' as typename, -2 as type, N'Không Dùng' as isusing, 1 as using from smartcard where using = 0)
                union
                (select count(identify) as total, N'Tổng thẻ' as typename, -3 as type, N'Dùng & Không' as isusing, 1 as using from smartcard )) a
                 order by type asc";

                var statistical = db.Database.SqlQuery<Statistical>(sqlString).ToList();

                responseCard = new ResponseCard() { ListCard = listCard, Statistical = statistical };

               
            }
            return responseCard;


        }
        public List<ResponeCardCreateTicketMonth> GetResponseCardCreateTicketMonth(string code)
        {
            List<ResponeCardCreateTicketMonth> listCard;
            using (DB db = new DB(code))
            {
                 string sql = "select s.Identify, s.ID, case s.Using when 1 then N'Đang sử dụng' else N'Đã khóa' end as Using, p.Name, case ISNULL(t.ID, 'NULL') when 'NULL' then N'Chưa tạo' else N'Đã tạo' end as TicketMonth, (select top 1 amount from part where id = type) as Amount from SmartCard s left join (select t.ID from TicketMonth t, (select ID, MAX(RowID) as 'RowID' from TicketMonth group by ID) tt where t.RowID = tt.RowID and t.Status in (0,1,3)) t on s.ID = t.ID, Part p where s.Type = p.ID  order by s.Identify";
                 listCard = db.Database.SqlQuery<ResponeCardCreateTicketMonth>(sql).ToList();
               
            }
            return listCard.Select(x=>x).Where(x=>x.TicketMonth.Equals("Chưa tạo")).OrderBy(x=>x.Identify).ToList();
        }


        public ResponseCard Statistical(string code)
        {
            string sqlString = @"select * from (
                            (select count(identify) as total, (select top 1 name from part where id = type) as typename, type, (case using when 'True' then N'Dùng' else N'Không dùng' end) as isusing,using from smartcard group by [type], using )
                union
                (select count(identify) as total, N'Tổng thẻ đang dùng' as typename, -1 as type, N'Dùng' as isusing, 1 as using from smartcard where using = 1)
                union
                (select count(identify) as total, N'Tổng thẻ không dùng' as typename, -2 as type, N'Không Dùng' as isusing, 1 as using from smartcard where using = 0)
                union
                (select count(identify) as total, N'Tổng thẻ' as typename, -3 as type, N'Dùng & Không' as isusing, 1 as using from smartcard )) a
                 order by type asc";
            ResponseCard reponsestatistical;
            using (DB db = new DB(code))
            {
                var statistical = db.Database.SqlQuery<Statistical>(sqlString).ToList();
                reponsestatistical = new ResponseCard { ListCard = null, Statistical = statistical };
            }           
            return reponsestatistical;
        }
        public CardReport GetCardReport(RequestCardReport requestCard)
        {
            try
            {
                CardReport cardReport = new CardReport();
                string sql2 = string.Format("SELECT  * from TicketMonth s left  JOIN (select ID, MAX(RowID) as 'RowID' from TicketMonth GROUP BY ID) t on s.ID = t.ID  where t.RowID = s.RowID and s.ProcessDate between '{0}' and '{1}'", requestCard.fromDate.ToString("yyyy-MM-dd"), requestCard.toDate.ToString("yyyy-MM-dd"));
                List<string> report = new List<string>();
                List<SmartCard> M1 = new List<SmartCard>();
                List<SmartCard> M2 = new List<SmartCard>();
                List<TicketMonthResult> ticketMonthResults1 = new List<TicketMonthResult>();
                List<TicketMonthResult> ticketMonthResults2 = new List<TicketMonthResult>();

                using (DB db = new DB("M1"))
                {
                    M1 = db.SmartCards.Where(x=> x.DayUnlimit <= requestCard.toDate).ToList();
                    ticketMonthResults1 = db.Database.SqlQuery<TicketMonthResult>(sql2).ToList();


                }
                using (DB db = new DB("M2"))
                {
                    M2 = db.SmartCards.Where(x => x.DayUnlimit <= requestCard.toDate).ToList();
                    ticketMonthResults2 = db.Database.SqlQuery<TicketMonthResult>(sql2).ToList();
                }

                cardReport.Total = M1.Count() + M2.Count();
                cardReport.TotalUsing = M1.Count(x => x.Using == true) + M2.Count(x => x.Using == true); ;
                cardReport.TotalBlock = cardReport.Total - cardReport.TotalUsing;
                cardReport.TotalTicketMonth = ticketMonthResults1.Count() + ticketMonthResults2.Count();
                cardReport.TotalGuest = cardReport.Total - cardReport.TotalTicketMonth;
                cardReport.TotalStopUsingTicketMonth = ticketMonthResults1.Count(x => x.Status == 3) + ticketMonthResults2.Count(x => x.Status == 3);
                cardReport.TotalBlackTicketMonth = ticketMonthResults1.Count(x => x.Status == 4) + ticketMonthResults2.Count(x => x.Status == 4);
                cardReport.TotalTicketMonthUsing = cardReport.TotalTicketMonth - (cardReport.TotalStopUsingTicketMonth + cardReport.TotalBlackTicketMonth);

                return cardReport;
            }
            catch
            {
                throw new NullReferenceException();
            }
        }
    }
}