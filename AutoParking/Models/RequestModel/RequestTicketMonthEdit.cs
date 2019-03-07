using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoParking.Models.RequestModel
{
    public class RequestTicketMonthEdit
    {
        /// <summary>
        /// ID tài khoản người cập nhật
        /// </summary>
        [Required]
        public string blockCode { set; get; }
        [Required]
        public int rowID { set; get; }

        public string IdAccountEdit { get; set; }

        /// <summary>
        /// Số thứ tự
        /// </summary>
        
        public int? Stt { get; set; }

        /// <summary>
        /// Biển số
        /// </summary>
        
        public string Digit { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string TenKH { get; set; }

        /// <summary>
        /// Chứng minh nhân dân
        /// </summary>
        public string CMND { get; set; }

        /// <summary>
        /// Công ty
        /// </summary>
        public string Company { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Hiệu xe
        /// </summary>
        public string CarKind { get; set; }

        /// <summary>
        /// Id hiệu xe
        /// </summary>
     
        public string IDPart { get; set; }

        /// <summary>
        /// Ngày đăng ký. Ví dụ: 2018-11-24 00:00:00
        /// </summary>
        
        public DateTime? fromDate { get; set; }

        /// <summary>
        /// Ngày hết hạng. Ví dụ: 2018-12-24 23:59:00
        /// </summary>
     
        public DateTime? toDate { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Số tiền
        /// </summary>
        
        public int? Amount { get; set; }
    }
}