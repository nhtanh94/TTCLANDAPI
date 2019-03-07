using AutoParking.Controllers;
using AutoParking.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AutoParking.Models
{
    public class LogViewModel : BaseController
    {
        //đã fix
        public void AddLog(string actionType, DateTime timeLog, string info ,string Code)
        {
            Log log;
            using(DB db = new DB(Code))
            {
                log = new Log() { LoaiThaoTac = actionType, NgayXuly = timeLog, May = "API", NguoiXuLy = "API", ThongTin = info };
                db.Logs.Add(log);
                db.SaveChanges();
            }                                            
        }

        public void AddTicketMonthLog(TicketMonth ticketMonth, string actionType, string nameUserCreateLog,string Code)
        {
              
            using(DB db = new DB(Code))
            {
                try
                {
                    if (ticketMonth == null)
                    {
                        Debug.WriteLine("TicketMonth null không thể tạo log");
                        return;
                    }
                    var dateTime = DateTime.Now;
                    var ticketLog = new TicketLog()
                    {
                        RowID = ticketMonth.RowID,
                        ProcessType = actionType,
                        STT = ticketMonth.Stt.ToString(),
                        ID = ticketMonth.ID,
                        DateProcess = dateTime,
                        Digit = ticketMonth.Digit,
                        TenKH = ticketMonth.TenKH,
                        CMND = ticketMonth.CMND,
                        Company = ticketMonth.Company,
                        EMail = ticketMonth.Email,
                        Address = ticketMonth.Address,
                        CarKind = ticketMonth.CarKind,
                        IDPart = ticketMonth.IDPart,
                        DateStart = ticketMonth.DateStart.ToString(),
                        DateEnd = ticketMonth.DateEnd.ToString(),
                        Note = ticketMonth.Note,
                        Amount = ticketMonth.Amount,
                        ChargesAmount = ticketMonth.ChargesAmount,
                        Account = nameUserCreateLog,
                        Images = ticketMonth.Images,
                        DayUnLimit = String.Format("{0:MMM dd yyyy hh:mm tt}", ticketMonth.DayUnLimit.Value),
                    };
                    db.TicketLogs.Add(ticketLog);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Không thể tạo log: " + e.Message);
                    Debug.WriteLine("Không thể tạo log: " + e.StackTrace);
                }
            }
            
            
        
        }

        public void AddTicketMonthLogEdit(TicketMonth ticketMonthOld, TicketMonth ticketMonthNew, string actionType, string nameUserCreateLog,string Code)
        {
            using (DB db = new DB(Code))
            {
                try
                {
                    if (ticketMonthOld == null || ticketMonthNew == null)
                    {
                        Debug.WriteLine("TicketMonth null không thể tạo log");
                        return;
                    }

                    var dateTime = DateTime.Now;
                    var ticketLog = new TicketLog()
                    {
                        RowID = ticketMonthNew.RowID,
                        ProcessType = actionType,
                        STT = (ticketMonthOld.Stt != ticketMonthNew.Stt) ? ticketMonthOld.Stt + "->" + ticketMonthNew.Stt : ticketMonthNew.Stt + "",
                        ID = (!(ticketMonthOld.ID + "").Equals(ticketMonthNew.ID + "")) ? ticketMonthOld.ID + "->" + ticketMonthNew.ID : ticketMonthNew.ID + "",
                        DateProcess = dateTime,
                        Digit = (!ticketMonthOld.Digit.Equals(ticketMonthNew.Digit + "")) ? ticketMonthOld.Digit + "->" + ticketMonthNew.Digit : ticketMonthNew.Digit + "",
                        TenKH = (!(ticketMonthOld.TenKH + "").Equals(ticketMonthNew.TenKH + "")) ? ticketMonthOld.TenKH + "->" + ticketMonthNew.TenKH : ticketMonthNew.TenKH + "",
                        CMND = (!(ticketMonthOld.CMND + "").Equals(ticketMonthNew.CMND + "")) ? ticketMonthOld.CMND + "->" + ticketMonthNew.CMND : ticketMonthNew.CMND + "",
                        Company = (!(ticketMonthOld.Company + "").Equals(ticketMonthNew.Company + "")) ? ticketMonthOld.Company + "->" + ticketMonthNew.Company : ticketMonthNew.Company + "",
                        EMail = (!(ticketMonthOld.Email + "").Equals(ticketMonthNew.Email + "")) ? ticketMonthOld.Email + "->" + ticketMonthNew.Email : ticketMonthNew.Email + "",
                        Address = (!(ticketMonthOld.Address + "").Equals(ticketMonthNew.Address + "")) ? ticketMonthOld.Address + "->" + ticketMonthNew.Address : ticketMonthNew.Address + "",
                        CarKind = (!(ticketMonthOld.CarKind + "").Equals(ticketMonthNew.CarKind + "")) ? ticketMonthOld.CarKind + "->" + ticketMonthNew.CarKind : ticketMonthNew.CarKind + "",
                        IDPart = (ticketMonthOld.IDPart != ticketMonthNew.IDPart) ? ticketMonthOld.IDPart + "->" + ticketMonthNew.IDPart : ticketMonthNew.IDPart + "",
                        DateStart = (!(ticketMonthOld.DateStart + "").Equals((ticketMonthNew.DateStart + ""))) ? (ticketMonthOld.DateStart + "") + "->" + (ticketMonthNew.DateStart + "") : ticketMonthNew.DateStart + "",
                        DateEnd = (!(ticketMonthOld.DateEnd + "").Equals(ticketMonthNew.DateEnd + "")) ? ticketMonthOld.DateEnd + "" + "->" + (ticketMonthNew.DateEnd + "") : ticketMonthNew.DateEnd + "",
                        Note = (!(ticketMonthOld.Note + "").Equals(ticketMonthNew.Note + "")) ? ticketMonthOld.Note + "->" + ticketMonthNew.Note : ticketMonthNew.Note + "",
                        Amount = (!(ticketMonthOld.Amount + "").Equals(ticketMonthNew.Amount + "")) ? ticketMonthOld.Amount + "->" + ticketMonthNew.Amount : ticketMonthNew.Amount + "",
                        ChargesAmount = (!(ticketMonthOld.ChargesAmount + "").Equals(ticketMonthNew.ChargesAmount + "")) ? ticketMonthOld.ChargesAmount + "->" + ticketMonthNew.ChargesAmount : ticketMonthNew.ChargesAmount + "",
                        Account = nameUserCreateLog,
                        Images = ticketMonthOld.Images,
                        DayUnLimit = String.Format("{0:MMM dd yyyy hh:mm tt}", ticketMonthNew.DayUnLimit.Value + "")
                    };
                    db.TicketLogs.Add(ticketLog);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Không thể tạo log: " + e.Message);
                    Debug.WriteLine("Không thể tạo log: " + e.StackTrace);
                }
            }
            
            
            
       
        }
    }
}